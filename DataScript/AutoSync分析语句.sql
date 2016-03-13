--原料采购入库

select * from ICStockBill where FTranType=1 order by FInterID desc
select * from ICStockBillEntry where FinterID=131307
union all
select * from ICStockBillEntry where FinterID=131277



select FEmpID,* from POOrder where FBillNo='DZLX-CGDD20151125-04'

SELECT * FROM ICTransactionType

select * from POInstock order by FInterID desc



--成品入库
select * from ICStockBill where FTranType=2 order by FInterID desc
select * from ICStockBillEntry where FinterID=131299
union all
select * from ICStockBillEntry where FinterID=131296

--成品出库
select * from ICStockBill where FTranType=21 order by FInterID desc
select * from ICStockBillEntry where FinterID=131302
union all
select * from ICStockBillEntry where FinterID=131289


--原料领料
select * from ICStockBill where FTranType=24 order by FInterID desc

select * from ICStockBillEntry where FinterID=131302
union all
select * from ICStockBillEntry where FinterID=131289