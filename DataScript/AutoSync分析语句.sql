--ԭ�ϲɹ����

select * from ICStockBill where FTranType=1 order by FInterID desc
select * from ICStockBillEntry where FinterID=131307
union all
select * from ICStockBillEntry where FinterID=131277



select FEmpID,* from POOrder where FBillNo='DZLX-CGDD20151125-04'

SELECT * FROM ICTransactionType

select * from POInstock order by FInterID desc



--��Ʒ���
select * from ICStockBill where FTranType=2 order by FInterID desc
select * from ICStockBillEntry where FinterID=131299
union all
select * from ICStockBillEntry where FinterID=131296

--��Ʒ����
select * from ICStockBill where FTranType=21 order by FInterID desc
select * from ICStockBillEntry where FinterID=131302
union all
select * from ICStockBillEntry where FinterID=131289


--ԭ������
select * from ICStockBill where FTranType=24 order by FInterID desc

select * from ICStockBillEntry where FinterID=131302
union all
select * from ICStockBillEntry where FinterID=131289