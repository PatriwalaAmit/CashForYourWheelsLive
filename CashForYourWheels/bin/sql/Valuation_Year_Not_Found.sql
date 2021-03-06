USE [carweb]
GO
/****** Object:  StoredProcedure [dbo].[valuation_process]    Script Date: 09/16/2020 07:49:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: SQLQuery2.sql|7|0|C:\Users\admin\AppData\Local\Temp\2\~vsC53A.sql
ALTER PROCEDURE [dbo].[valuation_process]
	@UVTID varchar(20),
	@Year int,
	@Month int,
	@Mileage varchar(500)	
AS
BEGIN

declare @sesionid varchar(100)
set @sesionid= SUBSTRING(@Mileage,CharIndex('!!',@Mileage)+2,LEN(@Mileage))
set @Mileage = SUBSTRING(@Mileage,1,CharIndex('!!',@Mileage)-1)
set @Mileage = @Mileage / 1000

declare @UVTMonth as int
declare @UVTPubDate as date
declare @newValuationId as int

if @Year =-1
begin 
	-- code by Amit select * from dbo.tbl_valuation_tmp where (uvt_id=@UVTID or uvt_pubseq=@UVTID) and ltrim(rtrim(sessionid))=ltrim(rtrim(@sesionid)) and Uvt_Mileage=@Mileage order by ID desc	
	if((select COUNT(*) from dbo.tbl_valuation_tmp where uvt_id=@UVTID and Uvt_Mileage=@Mileage and ltrim(rtrim(sessionid))=ltrim(rtrim(@sesionid)))>0)
		begin
			select top 1 * from dbo.tbl_valuation_tmp where (uvt_id=@UVTID or uvt_pubseq=@UVTID) and Uvt_Mileage=@Mileage order by ID desc	
			return
		end	
	else
		begin
		-- get latest Pub_Date Data using the Month and Mileage		
			
			create table #tableValuation_1 
			(uvt_pubseq int,uvt_pubdate datetime,uvt_ID int,Uvt_Year int,uvt_month int,Uvt_Mileage int,uvt_retail int,uvt_clean int,uvt_average int,uvt_below int)

			
			set @UVTMonth =  (select distinct  top(1) uvt_month from PUB_CAR.dbo.UsedValuesTrade where uvt_id = @UVTID and uvt_year = @Year 
							  and uvt_month<=@Month order by uvt_month desc)
							  
			set @Year = (select top(1) Uvt_Year from PUB_CAR.dbo.UsedValuesTrade where uvt_id = @UVTID and Uvt_Year=@UVTMonth ORDER BY uvt_pubdate desc)
			
			set @UVTPubDate = (select top(1) MAX(uvt_pubdate) from PUB_CAR.dbo.UsedValuesTrade where uvt_id = @UVTID and Uvt_Year=@Year)

			insert into #tableValuation_1
			(uvt_pubseq,uvt_pubdate,uvt_ID,Uvt_Year,uvt_month,Uvt_Mileage,uvt_retail,uvt_clean,uvt_average,uvt_below)
			--select distinct * from dbo.View_UsedValuesTrade where uvt_id = @UVTID and uvt_year = @Year and uvt_month = @UVTMonth and uvt_pubdate = @UVTPubDate 
			select distinct * from PUB_CAR.dbo.UsedValuesTrade where uvt_id = @UVTID and uvt_year = @Year and uvt_month = @UVTMonth and uvt_pubdate = @UVTPubDate 

			if((select count(*) from #tableValuation_1 where Uvt_Mileage = @Mileage)=1)
				begin
					insert into dbo.tbl_valuation_tmp
					(uvt_pubseq,uvt_pubdate,uvt_ID,Uvt_Year,uvt_month,Uvt_Mileage,uvt_retail,uvt_clean,uvt_average,uvt_below,sessionid)
					select *,@sesionid from #tableValuation_1 where Uvt_Mileage = @Mileage
					
					SELECT @newValuationId = SCOPE_IDENTITY()
				end
			else 
				begin
					create table #tableValuationfinal_1 (uvt_pubseq int,uvt_pubdate datetime,uvt_ID int,Uvt_Year int,uvt_month int,Uvt_Mileage int,uvt_retail int,uvt_clean int,uvt_average int,uvt_below int)

					insert into #tableValuationfinal_1 
					select * from (select top 1 * from #tableValuation_1 where Uvt_Mileage >= @Mileage order by Uvt_Mileage ASC)a

					update #tableValuationfinal_1 
					set 
					uvt_average = (#tableValuationfinal_1 .uvt_average - (floor((#tableValuationfinal_1.uvt_average -b.uvt_average)/(b.uvt_Mileage - #tableValuationfinal_1.Uvt_Mileage))	* (@Mileage-#tableValuationfinal_1.Uvt_Mileage))),
					uvt_clean = (#tableValuationfinal_1 .uvt_clean - (floor((#tableValuationfinal_1.uvt_clean -b.uvt_clean)/(b.uvt_Mileage - #tableValuationfinal_1.Uvt_Mileage))	* (@Mileage-#tableValuationfinal_1.Uvt_Mileage))),
					uvt_below = (#tableValuationfinal_1 .uvt_below - (floor((#tableValuationfinal_1.uvt_below -b.uvt_below)/(b.uvt_Mileage - #tableValuationfinal_1.Uvt_Mileage))	* (@Mileage-#tableValuationfinal_1.Uvt_Mileage))),
					#tableValuationfinal_1.Uvt_Mileage = @Mileage 
					
					from (select top 1 * from #tableValuation_1 where Uvt_Mileage <= @Mileage ORDER BY Uvt_Mileage DESC)b
					where #tableValuationfinal_1 .uvt_pubseq = b.uvt_pubseq

					insert into dbo.tbl_valuation_tmp
					(uvt_pubseq,uvt_pubdate,uvt_ID,Uvt_Year,uvt_month,Uvt_Mileage,uvt_retail,uvt_clean,uvt_average,uvt_below,sessionid)
					select uvt_pubseq,uvt_pubdate,uvt_ID,Uvt_Year,uvt_month,Uvt_Mileage,uvt_retail,uvt_clean,dbo.rounding_roundCleanAverageBelow(uvt_average)
					,uvt_below,@sesionid from #tableValuationfinal_1
					
					SELECT @newValuationId = SCOPE_IDENTITY()

					select uvt_pubseq,uvt_pubdate,uvt_ID,Uvt_Year,uvt_month,Uvt_Mileage,
					uvt_retail,
					dbo.rounding_roundCleanAverageBelow(uvt_average) as uvt_average,
					dbo.rounding_roundCleanAverageBelow(uvt_clean) as uvt_clean,
					dbo.rounding_roundCleanAverageBelow(uvt_average) as uvt_average1,
					dbo.rounding_roundCleanAverageBelow(uvt_below) as uvt_below 
					from #tableValuationfinal_1
					
					drop table #tableValuationfinal_1

				end
				
			drop table #tableValuation_1
			
			SELECT * FROM dbo.tbl_valuation_tmp WHERE Id = @newValuationId

		end
end
--else
begin
	if((select COUNT(*) from dbo.tbl_valuation_tmp where uvt_id=@UVTID and Uvt_Mileage=@Mileage and sessionid=@sesionid)>0)
		begin
			select * from dbo.tbl_valuation_tmp where uvt_id=@UVTID and Uvt_Mileage=@Mileage and sessionid=@sesionid and uvt_month=@Month and Uvt_Year=@Year order by ID desc
		end
	else
		begin			
			
			create table #tableValuation 
			(uvt_pubseq int,uvt_pubdate datetime,uvt_ID int,Uvt_Year int,uvt_month int,Uvt_Mileage int,uvt_retail int,uvt_clean int,uvt_average int,uvt_below int)

			set @UVTMonth =  (select distinct  top(1) uvt_month from PUB_CAR.dbo.UsedValuesTrade where uvt_id = @UVTID and uvt_year = @Year and uvt_month<=@Month order by uvt_month desc)
			set @UVTPubDate = (select top(1) MAX(uvt_pubdate) from PUB_CAR.dbo.UsedValuesTrade where uvt_id = @UVTID and Uvt_Year=@Year)

			insert into #tableValuation
			(uvt_pubseq,uvt_pubdate,uvt_ID,Uvt_Year,uvt_month,Uvt_Mileage,uvt_retail,uvt_clean,uvt_average,uvt_below)
			--select distinct * from dbo.View_UsedValuesTrade where uvt_id = @UVTID and uvt_year = @Year and uvt_month = @UVTMonth and uvt_pubdate = @UVTPubDate 
			select distinct * from PUB_CAR.dbo.UsedValuesTrade where uvt_id = @UVTID and uvt_year = @Year and uvt_month = @UVTMonth and uvt_pubdate = @UVTPubDate 

			if((select count(*) from #tableValuation where Uvt_Mileage = @Mileage)=1)
				begin
					insert into dbo.tbl_valuation_tmp
					(uvt_pubseq,uvt_pubdate,uvt_ID,Uvt_Year,uvt_month,Uvt_Mileage,uvt_retail,uvt_clean,uvt_average,uvt_below,sessionid)
					select *,@sesionid from #tableValuation where Uvt_Mileage = @Mileage
					
					SELECT @newValuationId = SCOPE_IDENTITY()
				end
			else 
				begin
					create table #tableValuationfinal (uvt_pubseq int,uvt_pubdate datetime,uvt_ID int,Uvt_Year int,uvt_month int,Uvt_Mileage int,uvt_retail int,uvt_clean int,uvt_average int,uvt_below int)

					insert into #tableValuationfinal 
					select * from (select top 1 * from #tableValuation where Uvt_Mileage >= @Mileage order by Uvt_Mileage ASC)a

					update #tableValuationfinal 
					set 
					uvt_average = (#tableValuationfinal .uvt_average - (floor((#tableValuationfinal.uvt_average -b.uvt_average)/(b.uvt_Mileage - #tableValuationfinal.Uvt_Mileage))	* (@Mileage-#tableValuationfinal.Uvt_Mileage))),
					uvt_clean = (#tableValuationfinal .uvt_clean - (floor((#tableValuationfinal.uvt_clean -b.uvt_clean)/(b.uvt_Mileage - #tableValuationfinal.Uvt_Mileage))	* (@Mileage-#tableValuationfinal.Uvt_Mileage))),
					uvt_below = (#tableValuationfinal .uvt_below - (floor((#tableValuationfinal.uvt_below -b.uvt_below)/(b.uvt_Mileage - #tableValuationfinal.Uvt_Mileage))	* (@Mileage-#tableValuationfinal.Uvt_Mileage))),
					#tableValuationfinal.Uvt_Mileage = @Mileage 
					
					from (select top 1 * from #tableValuation where Uvt_Mileage <= @Mileage ORDER BY Uvt_Mileage DESC)b
					where #tableValuationfinal .uvt_pubseq = b.uvt_pubseq

					insert into dbo.tbl_valuation_tmp
					(uvt_pubseq,uvt_pubdate,uvt_ID,Uvt_Year,uvt_month,Uvt_Mileage,uvt_retail,uvt_clean,uvt_average,uvt_below,sessionid)
					select uvt_pubseq,uvt_pubdate,uvt_ID,Uvt_Year,uvt_month,Uvt_Mileage,uvt_retail,uvt_clean,dbo.rounding_roundCleanAverageBelow(uvt_average)
					,uvt_below,@sesionid from #tableValuationfinal
					
					SELECT @newValuationId = SCOPE_IDENTITY()

					select uvt_pubseq,uvt_pubdate,uvt_ID,Uvt_Year,uvt_month,Uvt_Mileage,
					uvt_retail,
					dbo.rounding_roundCleanAverageBelow(uvt_average) as uvt_average,
					dbo.rounding_roundCleanAverageBelow(uvt_clean) as uvt_clean,
					dbo.rounding_roundCleanAverageBelow(uvt_average) as uvt_average1,
					dbo.rounding_roundCleanAverageBelow(uvt_below) as uvt_below 
					from #tableValuationfinal
					
					drop table #tableValuationfinal

				end
				
			drop table #tableValuation
			
			SELECT * FROM dbo.tbl_valuation_tmp WHERE Id = @newValuationId
	end 
end

--DBCC FREESYSTEMCACHE
--DBCC FREESESSIONCACHE
--DBCC FREEPROCCACHE

END