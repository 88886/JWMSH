USE [master]
GO
/****** Object:  Database [JWMSH_2016]    Script Date: 2016/3/1 6:51:12 ******/
CREATE DATABASE [JWMSH_2016]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'JWMSH_2016', FILENAME = N'E:\DataBase64\JWMSH_2016.mdf' , SIZE = 10240KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'JWMSH_2016_log', FILENAME = N'E:\DataBase64\JWMSH_2016_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [JWMSH_2016] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [JWMSH_2016].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [JWMSH_2016] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [JWMSH_2016] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [JWMSH_2016] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [JWMSH_2016] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [JWMSH_2016] SET ARITHABORT OFF 
GO
ALTER DATABASE [JWMSH_2016] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [JWMSH_2016] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [JWMSH_2016] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [JWMSH_2016] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [JWMSH_2016] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [JWMSH_2016] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [JWMSH_2016] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [JWMSH_2016] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [JWMSH_2016] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [JWMSH_2016] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [JWMSH_2016] SET  DISABLE_BROKER 
GO
ALTER DATABASE [JWMSH_2016] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [JWMSH_2016] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [JWMSH_2016] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [JWMSH_2016] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [JWMSH_2016] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [JWMSH_2016] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [JWMSH_2016] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [JWMSH_2016] SET RECOVERY FULL 
GO
ALTER DATABASE [JWMSH_2016] SET  MULTI_USER 
GO
ALTER DATABASE [JWMSH_2016] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [JWMSH_2016] SET DB_CHAINING OFF 
GO
ALTER DATABASE [JWMSH_2016] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [JWMSH_2016] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'JWMSH_2016', N'ON'
GO
USE [JWMSH_2016]
GO
/****** Object:  StoredProcedure [dbo].[AddLogAction]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		upjd
-- Create date: 2014-12-21
-- Description:	添加日志记录
-- =============================================
Create PROCEDURE [dbo].[AddLogAction]
	@cFunction nvarchar(255),
	@cDescription nvarchar(255)
AS
BEGIN
	INSERT INTO BLogAction
	(
		-- id -- this column value is auto-generated
		cFunction,
		cDescription,
		dDate
	)
	VALUES
	(
		@cFunction,
		@cDescription,
		GETDATE()
	)
END


GO
/****** Object:  StoredProcedure [dbo].[GenRoleFunction]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:upjd
-- Create date:20140803
-- Description:	创建默认权限
-- =============================================
CREATE PROCEDURE [dbo].[GenRoleFunction]
	@rCode nvarchar(30)
AS
BEGIN
	INSERT INTO BRoleFunction
	(
		rCode,
		fCode
	)
	SELECT @rCode,cFunction 
	FROM BFunction  WHERE cFunction NOT IN (SELECT fCode FROM BRoleFunction  WHERE rCode=@rCode)
	
END

GO
/****** Object:  StoredProcedure [dbo].[GetRecordPage]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--获取记录并翻页
Create PROCEDURE [dbo].[GetRecordPage]
@PageIndex    int = 1,            -- 页码
@TableRecord nvarchar(50),
@fldName      nvarchar(255),       -- 字段名
@PageSize     int = 10,           -- 页尺寸
@strWhere     nvarchar(255) = '',  -- 查询条件(注意: 不要加where)
@PageCount int output,  --总页数，作为返回值
@RecordCount int output
AS
declare @i int
declare @j int
declare @strSQL   nvarchar(4000)       -- 主语句
declare @strOrder nvarchar(500)        -- 排序类型

begin

set @strOrder = ' order by [' + @fldName +'] desc'
set @j=(@PageIndex-1)*@PageSize
set @strSQL = 'SELECT top ' + str(@PageSize) + ' *
     FROM '+@TableRecord+'
     where [' + @fldName + '] not in(SELECT TOP '+ str(@j)+ ' [' + @fldName + ']
     FROM '+@TableRecord+' '+ @strOrder + ') '+ @strOrder
end
if @strWhere != ''
begin
    set @strSQL = 'select top ' + str(@PageSize) + ' * from ['
        + @TableRecord + '] where [' + @fldName + '] not in(select top ' + str(@j) + ' ['
        + @fldName + '] from [' + @TableRecord + '] where ' + @strWhere + ' '
        + @strOrder + ') and ' + @strWhere + ' ' + @strOrder
end
exec (@strSQL)
if @strWhere != ''
	begin
		set @strSQL = 'select @i=count(' + @fldName + ') from [' + @TableRecord + '] where ' + @strWhere + ' '--用来获取总记录数
	end
else
	begin
		set @strSQL = 'select @i=count(' + @fldName + ') from [' + @TableRecord + ']'--用来获取总记录数
	end
exec   sp_executesql   @strSQL,N'@i    int    output' ,@i  output
set @RecordCount = @i
/*得到总页数，注意使用convert先转换整型为浮点型，防止小数部分丢失*/
set @PageCount = ceiling ( convert( float,@i)/@PageSize)
return 






GO
/****** Object:  StoredProcedure [dbo].[proc_Bar_RawMaterialInsert]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		upjd
-- Create date: 20160110
-- Description:	新增原料标签记录
-- =============================================
CREATE PROCEDURE [dbo].[proc_Bar_RawMaterialInsert]
	@AutoID int = NULL output,
	@cSerialNumber nvarchar(155) = NULL output,
	@FitemID nvarchar(50)= NULL,
	@cInvCode nvarchar(50) = NULL,
	@cInvName nvarchar(255) = NULL,
	@cInvStd nvarchar(50) = NULL,
	@cFullName nvarchar(255),
	@cVendor nvarchar(50) = NULL,
	@cLotNo nvarchar(255) = NULL,
	@iQuantity float = NULL,
	@dDate datetime = NULL,
	@cMemo nvarchar(255) = NULL,
	@cDefaultLoc nvarchar(50)=null,
	@cDefaultSP nvarchar(50)=null,
	@cDefine1 nvarchar(255)=null,
	@cDefine2 nvarchar(255)=null
AS
BEGIN
	--定义变量
	declare  @temp nvarchar(50),@itemp int
	--取年月日121116
	set @temp=right((select convert(varchar(10),getdate(),112)),6)
	--判断当天是否开始入库
	set @itemp=(select COUNT(*) from RmLabel where substring(cSerialNumber,len(cSerialNumber)-9,6) =@temp)
	--如果大于零则是开始采购
	if @itemp>0
	set @cSerialNumber='RM'+(select top 1 @temp+
	Right('0000'+cast(convert(integer,right(cSerialNumber,4))+1 as varchar),4)
	from RmLabel where substring(cSerialNumber,len(cSerialNumber)-9,6) =@temp
	order by cSerialNumber desc)
	else
	set @cSerialNumber='RM'+(@temp+'0001')



	INSERT INTO [dbo].[RmLabel]
           ([cSerialNumber]
           ,[FitemID]
           ,[cInvCode]
           ,[cInvName]
           ,[cInvStd]
           ,[cFullName]
           ,[cDefaultLoc]
           ,[cDefaultSP]
           ,[cLotNo]
           ,[cVendor]
           ,[iQuantity]
           ,[dDate]
           ,[cMemo]
           ,[cDefine1]
           ,[cDefine2]
           ,[cDefine3]
           ,[cDefine4])
     VALUES
           (
			@cSerialNumber,
			@FitemID,
			@cInvCode,
			@cInvName,
			@cInvStd,
			@cFullName,
			@cDefaultLoc,
			@cDefaultSP,
			@cLotNo,
			@cVendor,
			@iQuantity,
			@dDate,
			@cMemo,
			@cDefine1,
			@cDefine2,
			'',
			'')
END

GO
/****** Object:  StoredProcedure [dbo].[proc_Bar_RawMaterialUpdate]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		upjd
-- Create date: 20160110
-- Description:	修改原料标签记录
-- =============================================
CREATE PROCEDURE [dbo].[proc_Bar_RawMaterialUpdate]
	@AutoID int = NULL,
	@FitemID nvarchar(50)= NULL,
	@cInvCode nvarchar(50) = NULL,
	@cInvName nvarchar(255) = NULL,
	@cInvStd nvarchar(50) = NULL,
	@cFullName nvarchar(255),
	@cVendor nvarchar(50) = NULL,
	@cLotNo nvarchar(255) = NULL,
	@iQuantity float = NULL,
	@dDate datetime = NULL,
	@cMemo nvarchar(255) = NULL,
	@cDefaultLoc nvarchar(50)=null,
	@cDefaultSP nvarchar(50)=null,
	@cDefine1 nvarchar(255)=null
AS
BEGIN
	SET NOCOUNT OFF
	DECLARE @Err int
	UPDATE RmLabel
	SET
		[cLotNo] = @cLotNo,
		[iQuantity] = @iQuantity,
		[dDate] = @dDate,
		[cInvCode] = @cInvCode,
		[cInvName] = @cInvName,
		[cInvStd] = @cInvStd,
		cFullName = @cFullName,
		[cVendor] = @cVendor,
		[cMemo] = @cMemo,
		cDefaultLoc=@cDefaultLoc,
		cDefaultSP=@cDefaultSP,
		cDefine1=@cDefine1

	WHERE
		[AutoID] = @AutoID


	SET @Err = @@Error


	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[proc_BomInsert]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		upjd
-- Create date: 20160112
-- Description:	新增BOM
-- =============================================
CREATE PROCEDURE [dbo].[proc_BomInsert] 
	@AutoID bigint output,
	@cFitemID nvarchar(30),
	@cInvCode nvarchar(50),
	@cInvName nvarchar(255),
	@cInvStd nvarchar(255),
	@cFullName nvarchar(255),
	@cMemo nvarchar(255)
AS
BEGIN
	if exists (select * from Bom where cInvCode=@cInvCode)
		return -1
	
	INSERT INTO [dbo].[Bom]
           ([cFitemID]
           ,[cInvCode]
           ,[cInvName]
           ,[cInvStd]
           ,[cFullName]
           ,[cMemo]
           ,[dAddTime])
     VALUES
           (@cFitemID
		   ,@cInvCode
		   ,@cInvName
		   ,@cInvStd
		   ,@cFullName
		   ,@cMemo
		   ,getdate())

	set @AutoID=@@IDENTITY
END

GO
/****** Object:  StoredProcedure [dbo].[proc_BomUpdate]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		upjd
-- Create date: 20160112
-- Description:	更新BOM
-- =============================================
CREATE PROCEDURE [dbo].[proc_BomUpdate] 
	@AutoID bigint,
	@cFitemID nvarchar(30),
	@cInvCode nvarchar(50),
	@cInvName nvarchar(255),
	@cInvStd nvarchar(255),
	@cFullName nvarchar(255),
	@cMemo nvarchar(255)
AS
BEGIN
	if not exists (select * from Bom where AutoID=@AutoID)
		return -1
	
	update Bom
	 SET [cFitemID] = @cFitemID
	    ,[cInvCode] = @cInvCode
	    ,[cInvName] = @cInvName
	    ,[cInvStd] = @cInvStd
	    ,[cFullName] =@cFullName
	    ,[cMemo] = @cMemo
	where AutoID=@AutoID
END

GO
/****** Object:  StoredProcedure [dbo].[proc_GenerateProductLabel]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		upjd
-- Create date: 20160114
-- Description:	创建成品序列号
-- =============================================
CREATE PROCEDURE [dbo].[proc_GenerateProductLabel]
	@cSerialNumber nvarchar(30),
	@iQuantity int,
	@SerialQty int,
	@cMemo nvarchar(255)
AS
BEGIN
	declare @MaxID int,@maxBarCode nvarchar(30),@i int;
	set @maxBarCode=(select top 1 cBarCode from ProductLabel where cSerialNumber=@cSerialNumber order by AutoID desc);
	if @maxBarCode='' or @maxBarCode is null
		set @MaxID=1;
	else
		set @MaxID=CONVERT(int,right(@maxBarCode,4))+1;


	set @i=0;
	while(@i<@SerialQty)
	begin
		INSERT INTO [dbo].[ProductLabel]
           ([cSerialNumber]
           ,[cBarCode]
           ,[iQuantity]
           ,[cDefine1]
           ,[cDefine2]
           ,[cDefine3]
           ,[cDefine4]
           ,[cMemo])
     VALUES
           (@cSerialNumber,
		   @cSerialNumber+right('0000'+Convert(nvarchar(30),@MaxID+@i),4),
		   @iQuantity,
		   '',
		   '',
		   '',
		   '',
		   @cMemo)
		set @i=@i+1;
	end

		

END

GO
/****** Object:  StoredProcedure [dbo].[proc_ShiftInsert]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		upjd
-- Create date: 20160112
-- Description:	新增班次制令单
-- =============================================
Create PROCEDURE [dbo].[proc_ShiftInsert] 
	@AutoID bigint output,
	@cSerialNumber nvarchar(155) = NULL output,
	@BomID bigint,
	@cFitemID nvarchar(30),
	@cInvCode nvarchar(50),
	@cInvName nvarchar(255),
	@cInvStd nvarchar(255),
	@cFullName nvarchar(255),
	@cOrderNumber nvarchar(50),
	@iQuantity int,
	@dDate date,
	@cDeptName nvarchar(255),
	@cMemo nvarchar(255)
AS
BEGIN

	--定义变量
	declare  @temp nvarchar(50),@itemp int
	--取年月日121116
	set @temp=right((select convert(varchar(10),getdate(),112)),6)
	--判断当天是否开始入库
	set @itemp=(select COUNT(*) from Shift where substring(cSerialNumber,len(cSerialNumber)-9,6) =@temp)
	--如果大于零则是开始采购
	if @itemp>0
	set @cSerialNumber='SF'+(select top 1 @temp+
	Right('0000'+cast(convert(integer,right(cSerialNumber,4))+1 as varchar),4)
	from Shift where substring(cSerialNumber,len(cSerialNumber)-9,6) =@temp
	order by cSerialNumber desc)
	else
	set @cSerialNumber='SF'+(@temp+'0001')

	INSERT INTO [dbo].[Shift]
           ([cSerialNumber]
           ,[BomID]
           ,[cFitemID]
           ,[cInvCode]
           ,[cInvName]
           ,[cInvStd]
           ,[cFullName]
           ,[cOrderNumber]
           ,[iQuantity]
           ,[dDate]
           ,[cMemo]
           ,[cDeptName]
           ,[dAddTime])
     VALUES
           (@cSerialNumber
		   ,@BomID
		   ,@cFitemID
		   ,@cInvCode
		   ,@cInvName
		   ,@cInvStd
		   ,@cFullName
		   ,@cOrderNumber
		   ,@iQuantity
		   ,@dDate
		   ,@cMemo
		   ,@cDeptName
		   ,getdate())

	set @AutoID=@@IDENTITY
END

GO
/****** Object:  StoredProcedure [dbo].[proc_ShiftUpdate]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		upjd
-- Create date: 20160112
-- Description:	新增班次制令单
-- =============================================
Create PROCEDURE [dbo].[proc_ShiftUpdate] 
	@AutoID bigint,
	@BomID bigint,
	@cFitemID nvarchar(30),
	@cInvCode nvarchar(50),
	@cInvName nvarchar(255),
	@cInvStd nvarchar(255),
	@cFullName nvarchar(255),
	@cOrderNumber nvarchar(50),
	@iQuantity int,
	@dDate date,
	@cDeptName nvarchar(255),
	@cMemo nvarchar(255)
AS
BEGIN

	UPDATE [dbo].[Shift]
   SET [BomID] = @BomID
      ,[cFitemID] = @cFitemID
      ,[cInvCode] = @cInvCode
      ,[cInvName] =@cInvName
      ,[cInvStd] =@cInvStd
      ,[cFullName] = @cFullName
      ,[cOrderNumber] = @cOrderNumber
      ,[iQuantity] = @iQuantity
      ,[dDate] = @dDate
      ,[cMemo] = @cMemo
      ,[cDeptName] = @cDeptName
	where AutoID=@AutoID
END

GO
/****** Object:  StoredProcedure [dbo].[Query_RmTrackingUseInProduct]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		upjd
-- Create date: 20160115	
-- Description:	Rm Batch Tracking
-- =============================================
CREATE PROCEDURE [dbo].[Query_RmTrackingUseInProduct]
	@cInvCode nvarchar(50),
	@FBatchNo nvarchar(50)
AS
BEGIN
	select * from View_ProductLabel where cSerialNumber in
	(select cSerialNumber from ShiftDetail where cInvCode=@cInvCode and FBatchNo=@FBatchNo group by cSerialNumber)
END

GO
/****** Object:  StoredProcedure [dbo].[SaveGridStyle]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,zqs>
-- Create date: <Create Date,,20140605>
-- Description:	<Description,,保存表格样式>
-- =============================================
CREATE PROCEDURE [dbo].[SaveGridStyle]
	@cFormID NVARCHAR(50),
	@cFormName NVARCHAR(50),
	@cKey NVARCHAR(50),
	@cCaption NVARCHAR(50),
	@iVisualPosition INT,
	@iWidth INT=null,
	@bHide bit
AS
BEGIN
	IF EXISTS(SELECT * FROM ColumnSeting WHERE cFormID=@cFormID AND cKey=@cKey)
		BEGIN
			UPDATE ColumnSeting SET cCaption =@cCaption,iVisualPosition = @iVisualPosition,bHide = @bHide,iWidth=@iWidth
			WHERE cFormID=@cFormID AND cKey=@cKey
		END
	ELSE
		BEGIN
			insert into ColumnSeting(cFormId,cFormName,cKey,cCaption,iVisualPosition,bHide,iWidth) Values(@cFormId,@cFormName,@cKey,@cCaption,@iVisualPosition,@bHide,@iWidth)
		
		END
END






GO
/****** Object:  StoredProcedure [dbo].[Upload_RmPo]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		upjd
-- Create date: 2014-12-21
-- Description:	上传二次拣货出库单
-- =============================================
CREATE PROCEDURE [dbo].[Upload_RmPo]
	@cOrderNumber       nvarchar(50), 
	@cInvCode       nvarchar(50), 
	@cInvName       nvarchar(255), 
	@cUnit       nvarchar(30)=null, 
	@iQuantity       decimal(18,4), 
	@iScanQuantity       decimal(18,4), 
	@cVendor       nvarchar(50),
	@cMemo	nvarchar(255),
	@cUser       nvarchar(50), 
	@cGuid       nvarchar(50),
	@FEntryID	int,
	@FItemID int
AS
BEGIN
	INSERT INTO [dbo].[Rm_Po]
           ([cOrderNumber]
           ,[cInvCode]
           ,[cInvName]
           ,[cUnit]
           ,[iQuantity]
           ,[iScanQuantity]
           ,[cVendor]
		   ,[cMemo]
           ,[dDate]
           ,[cUser]
           ,[cGuid]
		   ,FEntryID
		   ,FItemID)
	Values(	@cOrderNumber,
			@cInvCode,
			@cInvName,
			@cUnit,
			@iQuantity,
			@iScanQuantity,
			@cVendor,
			@cMemo,
			getdate(),
			@cUser,
			@cGuid,
			@FEntryID,
			@FItemID)

	--if  not exists(select * from Wms_M_Eas where cGuid=@cGuid)
	--begin 
	--	--定义变量
	--	declare  @temp nvarchar(50),@itemp int,@cEasNewOrder nvarchar(50)
	--	--取年月日121116
	--	set @temp=right((select convert(varchar(10),getdate(),112)),6)
	--	--判断当天是否开始入库
	--	set @itemp=(select COUNT(*) from Wms_M_Eas where substring(cEasNewOrder,len(cEasNewOrder)-8,6) =@temp and cType='采购收货')
	--	--如果大于零则是开始采购
	--	if @itemp>0
	--	set @cEasNewOrder='RO'+(select top 1 @temp+
	--	Right('000'+cast(convert(integer,right(cEasNewOrder,3))+1 as varchar),3)
	--	from Wms_M_Eas where substring(cEasNewOrder,len(cEasNewOrder)-8,6) =@temp and cType='采购收货'
	--	order by cEasNewOrder desc)
	--	else
	--	set @cEasNewOrder='RO'+(@temp+'001')

	--	INSERT INTO [dbo].[Wms_M_Eas]
 --          ([cType]
 --          ,[cGuid]
 --          ,[cOrderNumber]
	--	   ,cEasNewOrder
 --          ,[cState])
 --    VALUES
 --          ('采购收货',
	--	   @cGuid,
	--	   @cOrderNumber,
	--	   @cEasNewOrder,
	--	   '初始化'
	--	   )
		
	--end
			
END




GO
/****** Object:  StoredProcedure [dbo].[Upload_RmStoreDetail]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		upjd
-- Create date: 2014-12-21
-- Description:	上传采购收货记录
-- =============================================
CREATE PROCEDURE [dbo].[Upload_RmStoreDetail]
	@cSerialNumber nvarchar(50),
	@cOrderNumber     nvarchar(50),
	@cLotNo     nvarchar(50)=null, 
	@cInvCode       nvarchar(50), 
	@cInvName       nvarchar(255), 
	@cUnit       nvarchar(30)=null, 
	@iQuantity       decimal(18,4), 
	@dScanTime       datetime=null,  
	@cUser       nvarchar(50), 
	@cGuid       nvarchar(50),
	@FEntryID	int,
	@FitemID	int,
	@FSPNumber	nvarchar(50)
AS
BEGIN
	INSERT INTO [dbo].[Rm_StoreDetail]
           ([cSerialNumber]
           ,[cOrderNumber]
		   ,[cLotNo]
           ,[cInvCode]
           ,[cInvName]
           ,[cUnit]
           ,[iQuantity]
		   ,[dDate]
           ,[dScanTime]
           ,[cUser]
		   ,cGuid
		   ,FEntryID
		   ,FitemID	
		   ,FSPNumber
		   )
	Values(	@cSerialNumber,
			@cOrderNumber,
			@cLotNo,
			@cInvCode,
			@cInvName,
			@cUnit,
			@iQuantity,
			getdate(),
			@dScanTime,
			@cUser,
			@cGuid,
			@FEntryID,
			@FitemID,	
			@FSPNumber
			)
			
END




GO
/****** Object:  Table [dbo].[BDepartment]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BDepartment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[cDepCode] [nvarchar](30) NULL,
	[cDepName] [nvarchar](50) NULL,
	[cDepPerSon] [nvarchar](50) NULL,
	[dAddTime] [datetime] NULL DEFAULT (getdate()),
	[bEnable] [bit] NULL DEFAULT ((1)),
 CONSTRAINT [PK_BDEPARTMENT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BFunction]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BFunction](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[cFunction] [nvarchar](20) NULL,
	[cModule] [nvarchar](20) NULL,
	[bMenu] [bit] NULL,
	[cClass] [nvarchar](255) NULL,
 CONSTRAINT [PK_BFUNCTION] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BLogAction]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BLogAction](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[cFunction] [nvarchar](255) NULL,
	[cDescription] [nvarchar](255) NULL,
	[dDate] [datetime] NULL CONSTRAINT [DF_BLogAction_dDate]  DEFAULT (getdate()),
	[dAddTime] [datetime] NULL CONSTRAINT [DF_BLogAction_dAddTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_BLOGACTION] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Bom]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bom](
	[AutoID] [bigint] IDENTITY(1,1) NOT NULL,
	[cFitemID] [nvarchar](30) NULL,
	[cInvCode] [nvarchar](50) NULL,
	[cInvName] [nvarchar](255) NULL,
	[cInvStd] [nvarchar](255) NULL,
	[cFullName] [nvarchar](255) NULL,
	[cMemo] [nvarchar](50) NULL,
	[dAddTime] [datetime] NULL,
 CONSTRAINT [PK_Bom] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BomDetail]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BomDetail](
	[AutoID] [bigint] IDENTITY(1,1) NOT NULL,
	[BomID] [bigint] NOT NULL,
	[cFitemID] [nvarchar](30) NULL,
	[cInvCode] [nvarchar](50) NULL,
	[cInvName] [nvarchar](255) NULL,
	[iQuantity] [decimal](18, 10) NULL,
	[cUnitID] [nvarchar](50) NULL,
	[cUnitName] [nvarchar](50) NULL,
	[cInvStd] [nvarchar](255) NULL,
	[cFullName] [nvarchar](255) NULL,
	[cMemo] [nvarchar](50) NULL,
	[dAddTime] [datetime] NULL,
 CONSTRAINT [PK_BomDetail] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BPrinter]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BPrinter](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[cCaption] [nvarchar](50) NULL,
	[cIpAddress] [nvarchar](50) NULL,
	[cMemo] [nvarchar](50) NULL,
	[dAddtime] [datetime] NULL,
 CONSTRAINT [PK_BPrinter] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BRole]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BRole](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[cCode] [nvarchar](20) NULL,
	[cName] [nvarchar](30) NULL,
	[dAddTime] [datetime] NULL CONSTRAINT [DF_BRole_dAddTime]  DEFAULT (getdate()),
	[bEnable] [bit] NULL CONSTRAINT [DF_BRole_bEnable]  DEFAULT ((1)),
 CONSTRAINT [PK_BROLE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BRoleFunction]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BRoleFunction](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[rCode] [nvarchar](20) NULL,
	[fCode] [nvarchar](20) NULL,
	[bRight] [bit] NULL,
 CONSTRAINT [PK_BROLEFUNCTION] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BSetting]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BSetting](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[cName] [nvarchar](50) NULL,
	[cValue] [nvarchar](255) NULL,
	[cMemo] [nvarchar](255) NULL,
	[cDefine1] [nvarchar](255) NULL,
	[cDefine2] [int] NULL,
	[cDefine3] [decimal](16, 6) NULL,
 CONSTRAINT [PK_BSetting] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BTempletList]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BTempletList](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[cFunction] [nvarchar](50) NULL,
	[cCaption] [nvarchar](50) NULL,
	[cTempletPath] [nvarchar](100) NULL,
	[cPrinter] [nvarchar](100) NULL,
	[bDefault] [bit] NULL CONSTRAINT [DF_BTempletList_bDefault]  DEFAULT ((0)),
	[dAddTime] [datetime] NULL,
 CONSTRAINT [PK_BTEMPLETLIST] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BUser]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BUser](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[uCode] [nvarchar](20) NULL,
	[uName] [nvarchar](50) NULL,
	[uPassword] [nvarchar](50) NULL,
	[uRole] [nvarchar](20) NULL,
	[uDepartment] [nvarchar](20) NULL,
	[dAddTime] [datetime] NULL CONSTRAINT [DF_BUser_dAddTime]  DEFAULT (getdate()),
	[bEnable] [bit] NULL CONSTRAINT [DF_BUser_bEnable]  DEFAULT ((1)),
	[bOperator] [bit] NULL CONSTRAINT [DF_BUser_bOperator]  DEFAULT ((1)),
 CONSTRAINT [PK_BUSER] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ColumnSeting]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ColumnSeting](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[cFormID] [nvarchar](100) NULL,
	[cFormName] [nvarchar](100) NULL,
	[cKey] [nvarchar](100) NULL,
	[cCaption] [nvarchar](100) NULL,
	[iVisualPosition] [int] NULL,
	[bHide] [bit] NULL,
	[iWidth] [int] NULL CONSTRAINT [DF_ColumnSeting_iWidth]  DEFAULT ((100)),
 CONSTRAINT [PK_BCOLUMNSETTING] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProCheckScan]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProCheckScan](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[FItemID] [int] NULL,
	[cCode] [nvarchar](50) NULL,
	[cBarCode] [nvarchar](50) NULL,
	[cLotNo] [nvarchar](50) NULL,
	[cInvCode] [nvarchar](50) NULL,
	[cInvName] [nvarchar](50) NULL,
	[iQuantity] [int] NULL,
	[cPdaSN] [nvarchar](50) NULL,
	[cUser] [nvarchar](50) NULL,
	[dScanTime] [datetime] NULL,
	[cBoxNumber] [nvarchar](50) NULL,
	[dAddTime] [datetime] NULL,
	[cWhCode] [nvarchar](50) NULL,
	[cWhName] [nvarchar](100) NULL,
	[bUpdate] [bit] NULL,
 CONSTRAINT [PK_ProCheckScan] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProDelivery]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProDelivery](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[cCode] [nvarchar](30) NOT NULL,
	[dDate] [datetime] NULL,
	[cOrderCode] [nvarchar](30) NULL,
	[cCusCode] [nvarchar](30) NULL,
	[cCusName] [nvarchar](50) NULL,
	[cMaker] [nvarchar](50) NULL,
	[dMaketime] [datetime] NULL,
	[cModifyPerson] [nvarchar](50) NULL,
	[dModifyDate] [datetime] NULL,
	[cHandler] [nvarchar](50) NULL,
	[dVeriDate] [datetime] NULL,
	[cVerifyState] [nvarchar](50) NULL,
	[dAddTime] [datetime] NULL,
	[cMemo] [nvarchar](255) NULL,
	[cOrderType] [nvarchar](40) NULL,
	[iYuShouQi] [int] NULL,
	[OrderDate] [date] NULL,
	[DeliveryDate] [date] NULL,
	[cDepCode] [nvarchar](20) NULL,
	[cDepName] [nvarchar](50) NULL,
	[cOutType] [nvarchar](20) NULL,
 CONSTRAINT [PK_ProDelivery] PRIMARY KEY CLUSTERED 
(
	[cCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProDeliveryDetail]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProDeliveryDetail](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[ID] [int] NULL,
	[FItemID] [int] NULL,
	[cCode] [nvarchar](30) NULL,
	[cLotNo] [nvarchar](30) NULL,
	[cInvCode] [nvarchar](30) NULL,
	[cInvName] [nvarchar](50) NULL,
	[iRemainQuantity] [decimal](14, 4) NULL,
	[iOrderQuantity] [decimal](14, 4) NULL,
	[iQuantity] [decimal](14, 4) NULL,
	[cMemo] [nvarchar](255) NULL,
	[bUpdate] [bit] NULL,
	[cWhCode] [nvarchar](50) NULL,
	[cWhName] [nvarchar](50) NULL,
	[cInvStd] [nvarchar](50) NULL,
	[cUnit] [nvarchar](50) NULL,
	[dDate] [date] NULL,
	[dMassDate] [date] NULL,
	[iU8Quantity] [decimal](14, 4) NULL,
	[cBoxNumber] [nvarchar](50) NULL,
	[cWeight] [nvarchar](20) NULL,
 CONSTRAINT [PK_ProDeliveryDetail] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProDeliveryScan]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProDeliveryScan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cCode] [nvarchar](50) NULL,
	[FItemID] [int] NULL,
	[cBarCode] [nvarchar](50) NULL,
	[cLotNo] [nvarchar](50) NULL,
	[cInvCode] [nvarchar](50) NULL,
	[cInvName] [nvarchar](50) NULL,
	[iQuantity] [int] NULL,
	[cPdaSN] [nvarchar](50) NULL,
	[cUser] [nvarchar](50) NULL,
	[dScanTime] [datetime] NULL,
	[cBoxNumber] [nvarchar](50) NULL,
	[dAddTime] [datetime] NULL,
	[cWhCode] [nvarchar](50) NULL,
	[cWhName] [nvarchar](100) NULL,
	[bUpdate] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductLabel]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductLabel](
	[AutoID] [bigint] IDENTITY(1,1) NOT NULL,
	[cSerialNumber] [nvarchar](30) NULL,
	[cBarCode] [nvarchar](50) NULL,
	[iQuantity] [int] NULL,
	[cDefine1] [nvarchar](255) NULL,
	[cDefine2] [nvarchar](255) NULL,
	[cDefine3] [nvarchar](255) NULL,
	[cDefine4] [nvarchar](255) NULL,
	[cMemo] [nvarchar](255) NULL,
 CONSTRAINT [PK_ProductLabel] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProStoreDetail]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProStoreDetail](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[FItemID] [int] NULL,
	[cBoxNumber] [nvarchar](50) NULL,
	[cBarCode] [nvarchar](50) NULL,
	[cLotNo] [nvarchar](50) NULL,
	[cInvCode] [nvarchar](30) NULL,
	[cInvName] [nvarchar](50) NULL,
	[iQuantity] [decimal](14, 4) NULL,
	[bDelivery] [bit] NULL,
	[cMemo] [nvarchar](255) NULL,
	[dDate] [datetime] NULL,
	[cPdaSN] [nvarchar](50) NULL,
	[cUser] [nvarchar](50) NULL,
	[dScanTime] [datetime] NULL,
	[bUpdate] [bit] NULL,
	[dMassDate] [datetime] NULL,
 CONSTRAINT [PK_ProStoreDetail] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rm_Po]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rm_Po](
	[AutoID] [bigint] IDENTITY(1,1) NOT NULL,
	[cOrderNumber] [nvarchar](50) NULL,
	[cInvCode] [nvarchar](50) NULL,
	[cInvName] [nvarchar](255) NULL,
	[cUnit] [nvarchar](30) NULL,
	[iQuantity] [decimal](18, 4) NULL,
	[iScanQuantity] [decimal](18, 4) NULL,
	[cVendor] [nvarchar](50) NULL,
	[cMemo] [nvarchar](255) NULL,
	[dDate] [datetime] NULL,
	[cUser] [nvarchar](50) NULL,
	[cGuid] [nvarchar](50) NULL,
	[FEntryID] [int] NULL,
	[FItemID] [int] NULL,
 CONSTRAINT [PK_RmPo] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rm_StoreDetail]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rm_StoreDetail](
	[AutoID] [bigint] IDENTITY(1,1) NOT NULL,
	[cSerialNumber] [nvarchar](50) NULL,
	[cLotNo] [nvarchar](50) NULL,
	[cOrderNumber] [nvarchar](50) NULL,
	[cInvCode] [nvarchar](50) NULL,
	[cInvName] [nvarchar](255) NULL,
	[cUnit] [nvarchar](50) NULL,
	[iQuantity] [decimal](18, 4) NULL,
	[dDate] [datetime] NULL,
	[dScanTime] [datetime] NULL,
	[cUser] [nvarchar](50) NULL,
	[cGuid] [nvarchar](50) NULL,
	[FEntryID] [int] NULL,
	[FSPNumber] [nvarchar](50) NULL,
	[FitemID] [int] NULL,
 CONSTRAINT [PK_Rm_StoreDetail] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RmLabel]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RmLabel](
	[AutoID] [bigint] IDENTITY(1,1) NOT NULL,
	[cSerialNumber] [nvarchar](155) NULL,
	[FitemID] [nvarchar](50) NULL,
	[cInvCode] [nvarchar](50) NULL,
	[cInvName] [nvarchar](255) NULL,
	[cInvStd] [nvarchar](255) NULL,
	[cFullName] [nvarchar](255) NULL,
	[cDefaultLoc] [nvarchar](50) NULL,
	[cDefaultSP] [nvarchar](50) NULL,
	[cLotNo] [nvarchar](50) NULL,
	[cVendor] [nvarchar](255) NULL,
	[iQuantity] [decimal](18, 4) NULL,
	[dDate] [date] NULL,
	[cMemo] [nvarchar](255) NULL,
	[cDefine1] [nvarchar](255) NULL,
	[cDefine2] [nvarchar](255) NULL,
	[cDefine3] [nvarchar](255) NULL,
	[cDefine4] [nvarchar](255) NULL,
 CONSTRAINT [PK_RmLabel] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Shift]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shift](
	[AutoID] [bigint] IDENTITY(1,1) NOT NULL,
	[cSerialNumber] [nvarchar](30) NULL,
	[BomID] [bigint] NOT NULL,
	[cFitemID] [int] NULL,
	[FBatchNo] [nvarchar](50) NULL,
	[cInvCode] [nvarchar](50) NULL,
	[cInvName] [nvarchar](255) NULL,
	[cInvStd] [nvarchar](255) NULL,
	[cFullName] [nvarchar](255) NULL,
	[cOrderNumber] [nvarchar](50) NULL,
	[iQuantity] [int] NULL,
	[dDate] [date] NULL,
	[cMemo] [nchar](10) NULL,
	[cDeptName] [nvarchar](255) NULL,
	[dAddTime] [datetime] NULL CONSTRAINT [DF_Shift_dAddTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_Shift] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ShiftDetail]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShiftDetail](
	[AutoID] [bigint] IDENTITY(1,1) NOT NULL,
	[cSerialNumber] [nvarchar](30) NULL,
	[cFitemID] [int] NULL,
	[cInvCode] [nvarchar](50) NULL,
	[cInvName] [nvarchar](255) NULL,
	[cInvStd] [nvarchar](255) NULL,
	[cFullName] [nvarchar](255) NULL,
	[iQuantity] [decimal](18, 4) NULL,
	[FBatchNo] [nvarchar](50) NULL,
	[FStockID] [int] NULL,
	[FStockNumber] [nvarchar](50) NULL,
	[FStockName] [nvarchar](50) NULL,
	[FStockPlaceID] [int] NULL,
	[FStockPlaceNumber] [nvarchar](50) NULL,
	[FStockPlaceName] [nvarchar](50) NULL,
	[cMemo] [nchar](10) NULL,
	[dAddTime] [datetime] NULL,
 CONSTRAINT [PK_ShiftDetail] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tb_Collect]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_Collect](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[eKey] [nvarchar](50) NOT NULL,
	[cName] [nvarchar](100) NOT NULL,
	[tName] [nvarchar](50) NOT NULL,
	[cType] [nvarchar](50) NULL,
 CONSTRAINT [PK_Tb_Collect] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[View_BUserRole]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_BUserRole]
AS
SELECT   dbo.BRole.cCode AS rCode, dbo.BRole.cName AS rName, dbo.BUser.uCode AS cCode, dbo.BUser.uName AS cName, 
                dbo.BUser.uPassword AS cPwd, dbo.BUser.uDepartment, dbo.BUser.bOperator
FROM      dbo.BRole RIGHT OUTER JOIN
                dbo.BUser ON dbo.BRole.cCode = dbo.BUser.uRole

GO
/****** Object:  View [dbo].[View_ProductLabel]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_ProductLabel]
AS
SELECT   a.AutoID, a.cSerialNumber, a.cBarCode, a.iQuantity, a.cDefine1, a.cDefine2, a.cDefine3, a.cDefine4, a.cMemo, b.BomID, 
                b.cFitemID, b.cInvCode, b.cInvName, b.cInvStd, b.cFullName, b.cOrderNumber, b.iQuantity AS iSheduleQty, b.dDate, 
                b.cMemo AS iSheduleMemo, b.cDeptName, b.dAddTime
FROM      dbo.ProductLabel AS a INNER JOIN
                dbo.Shift AS b ON a.cSerialNumber = b.cSerialNumber

GO
/****** Object:  View [dbo].[View_RoleAndUser]    Script Date: 2016/3/1 6:51:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[View_RoleAndUser]
AS
SELECT   id, cCode, cName
FROM      BRole
union all 
SELECT   id, uCode, uName
FROM      BUser


GO
SET IDENTITY_INSERT [dbo].[BDepartment] ON 

INSERT [dbo].[BDepartment] ([ID], [cDepCode], [cDepName], [cDepPerSon], [dAddTime], [bEnable]) VALUES (1, N'D001', N'Huaxiang', N'demo', CAST(N'2016-01-09 15:45:38.213' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[BDepartment] OFF
SET IDENTITY_INSERT [dbo].[BFunction] ON 

INSERT [dbo].[BFunction] ([ID], [cFunction], [cModule], [bMenu], [cClass]) VALUES (1, N'原料标签打印', N'原料入库管理
', 1, N'JWMSH.WorkRmLabelPrint')
INSERT [dbo].[BFunction] ([ID], [cFunction], [cModule], [bMenu], [cClass]) VALUES (2, N'金蝶采购订单', N'原料入库管理
', 1, N'JWMSH.WorkRmPurchaseOrder')
INSERT [dbo].[BFunction] ([ID], [cFunction], [cModule], [bMenu], [cClass]) VALUES (3, N'产成品BOM管理', N'生产追溯管理
', 1, N'JWMSH.WorkTrackBom')
INSERT [dbo].[BFunction] ([ID], [cFunction], [cModule], [bMenu], [cClass]) VALUES (4, N'产成品BOM查询', N'生产追溯管理
', 1, N'JWMSH.WorkTrackBomQuery')
INSERT [dbo].[BFunction] ([ID], [cFunction], [cModule], [bMenu], [cClass]) VALUES (5, N'班次制令单', N'生产追溯管理
', 1, N'JWMSH.WorkTrackShiftOrder')
INSERT [dbo].[BFunction] ([ID], [cFunction], [cModule], [bMenu], [cClass]) VALUES (6, N'产成品标签打印', N'生产追溯管理
', 1, N'JWMSH.WorkTrackProductLabelPrint')
INSERT [dbo].[BFunction] ([ID], [cFunction], [cModule], [bMenu], [cClass]) VALUES (7, N'产成品拆箱', N'生产追溯管理
', 1, N'JWMSH.WorkTrackProductTransferBox')
INSERT [dbo].[BFunction] ([ID], [cFunction], [cModule], [bMenu], [cClass]) VALUES (8, N'产成品出库指令单', N'生产追溯管理
', 1, N'JWMSH.WorkTrackDeliveryOrder')
INSERT [dbo].[BFunction] ([ID], [cFunction], [cModule], [bMenu], [cClass]) VALUES (9, N'打印调拨单', N'生产追溯管理
', 1, N'JWMSH.WorkTrackPrintTransfer')
INSERT [dbo].[BFunction] ([ID], [cFunction], [cModule], [bMenu], [cClass]) VALUES (10, N'打印盘点单', N'生产追溯管理
', 1, N'JWMSH.WorkTrackPrintCheck')
INSERT [dbo].[BFunction] ([ID], [cFunction], [cModule], [bMenu], [cClass]) VALUES (11, N'原料标签打印记录表', N'报表管理', 1, N'JWMSH.RptRmLabelPrint')
INSERT [dbo].[BFunction] ([ID], [cFunction], [cModule], [bMenu], [cClass]) VALUES (12, N'原料采购入库明细表', N'报表管理', 1, N'JWMSH.RptRmStoreDetail')
INSERT [dbo].[BFunction] ([ID], [cFunction], [cModule], [bMenu], [cClass]) VALUES (13, N'用户管理', N'维护中心', 1, N'JWMSH.BaseUser')
INSERT [dbo].[BFunction] ([ID], [cFunction], [cModule], [bMenu], [cClass]) VALUES (14, N'角色权限管理', N'维护中心', 1, N'JWMSH.BaseRoleFunction')
INSERT [dbo].[BFunction] ([ID], [cFunction], [cModule], [bMenu], [cClass]) VALUES (15, N'表格样式维护', N'维护中心', 1, N'JWMSH.Base_ColumnSetting')
INSERT [dbo].[BFunction] ([ID], [cFunction], [cModule], [bMenu], [cClass]) VALUES (16, N'标签模版维护', N'维护中心', 1, N'JWMSH.Base_Templet')
INSERT [dbo].[BFunction] ([ID], [cFunction], [cModule], [bMenu], [cClass]) VALUES (17, N'产成品标签打印记录表', N'报表中心', 1, N'JWMSH.RptProLabelPrint')
INSERT [dbo].[BFunction] ([ID], [cFunction], [cModule], [bMenu], [cClass]) VALUES (18, N'产成品追溯表', N'报表中心', 1, N'JWMSH.RptProductSerialTracking')
INSERT [dbo].[BFunction] ([ID], [cFunction], [cModule], [bMenu], [cClass]) VALUES (19, N'原料批次追溯', N'报表中心', 1, N'JWMSH.RptRmLotTracking')
INSERT [dbo].[BFunction] ([ID], [cFunction], [cModule], [bMenu], [cClass]) VALUES (21, N'仓位标签打印', N'原料入库管理', 1, N'JWMSH.WorkStockPlaceLabelPrint')
SET IDENTITY_INSERT [dbo].[BFunction] OFF
SET IDENTITY_INSERT [dbo].[BLogAction] ON 

INSERT [dbo].[BLogAction] ([ID], [cFunction], [cDescription], [dDate], [dAddTime]) VALUES (1, N'采购订单下载', N'Demo下载采购订单：DZLX-CGDD20150630-04', CAST(N'2016-02-28 16:01:43.513' AS DateTime), CAST(N'2016-02-28 16:01:43.513' AS DateTime))
SET IDENTITY_INSERT [dbo].[BLogAction] OFF
SET IDENTITY_INSERT [dbo].[Bom] ON 

INSERT [dbo].[Bom] ([AutoID], [cFitemID], [cInvCode], [cInvName], [cInvStd], [cFullName], [cMemo], [dAddTime]) VALUES (1, N'1976', N'10.01.01.05.330121293', N'空气导流板', N'330 121 293', N'成品_上海大众_Santana B2_发动机仓件_空气导流板', N'', CAST(N'2016-01-12 20:52:20.293' AS DateTime))
INSERT [dbo].[Bom] ([AutoID], [cFitemID], [cInvCode], [cInvName], [cInvStd], [cFullName], [cMemo], [dAddTime]) VALUES (2, N'1977', N'10.01.01.05.330121407', N'补偿容器', N'330 121 407', N'成品_上海大众_Santana B2_发动机仓件_补偿容器', N'', CAST(N'2016-01-12 20:52:37.560' AS DateTime))
INSERT [dbo].[Bom] ([AutoID], [cFitemID], [cInvCode], [cInvName], [cInvStd], [cFullName], [cMemo], [dAddTime]) VALUES (3, N'1982', N'10.01.02.02.33D845051', N'GP4后风窗玻璃总成', N'33D 845 051', N'成品_上海大众_Santana Vista_风挡玻璃_GP4后风窗玻璃总成', N'', CAST(N'2016-01-12 20:55:54.330' AS DateTime))
INSERT [dbo].[Bom] ([AutoID], [cFitemID], [cInvCode], [cInvName], [cInvStd], [cFullName], [cMemo], [dAddTime]) VALUES (4, N'1986', N'10.01.02.02.33D845091', N'GP4前风窗玻璃总成', N'33D 845 091', N'成品_上海大众_Santana Vista_风挡玻璃_GP4前风窗玻璃总成', N'', CAST(N'2016-01-12 20:58:37.563' AS DateTime))
INSERT [dbo].[Bom] ([AutoID], [cFitemID], [cInvCode], [cInvName], [cInvStd], [cFullName], [cMemo], [dAddTime]) VALUES (5, N'1993', N'10.01.02.03.330857961B041', N'烟灰缸', N'330 857 961B 041', N'成品_上海大众_Santana Vista_内饰件_烟灰缸', N'', CAST(N'2016-01-12 20:59:05.117' AS DateTime))
INSERT [dbo].[Bom] ([AutoID], [cFitemID], [cInvCode], [cInvName], [cInvStd], [cFullName], [cMemo], [dAddTime]) VALUES (6, N'2010', N'10.01.02.03.330863243A233', N'副仪表板总成', N'330 863 243A 233', N'成品_上海大众_Santana Vista_内饰件_副仪表板总成', N'', CAST(N'2016-01-12 20:59:42.500' AS DateTime))
INSERT [dbo].[Bom] ([AutoID], [cFitemID], [cInvCode], [cInvName], [cInvStd], [cFullName], [cMemo], [dAddTime]) VALUES (7, N'2016', N'10.01.02.03.330863243AQ70', N'副仪表板总成', N'330 863 243A Q70', N'成品_上海大众_Santana Vista_内饰件_副仪表板总成', N'', CAST(N'2016-01-12 21:02:13.817' AS DateTime))
INSERT [dbo].[Bom] ([AutoID], [cFitemID], [cInvCode], [cInvName], [cInvStd], [cFullName], [cMemo], [dAddTime]) VALUES (8, N'2022', N'10.01.02.03.33D863241BSUT', N'副仪表板总成（B）', N'33D 863 241B SUT', N'成品_上海大众_Santana Vista_内饰件_副仪表板总成（B）', N'', CAST(N'2016-01-13 23:05:06.003' AS DateTime))
INSERT [dbo].[Bom] ([AutoID], [cFitemID], [cInvCode], [cInvName], [cInvStd], [cFullName], [cMemo], [dAddTime]) VALUES (9, N'2774', N'14.01.04.001', N'Touran左三角窗玻璃', N'1TO 845 411A', N'自制半成品_侧窗玻璃_清洁装箱_Touran左三角窗玻璃', N'', CAST(N'2016-01-16 10:16:03.770' AS DateTime))
INSERT [dbo].[Bom] ([AutoID], [cFitemID], [cInvCode], [cInvName], [cInvStd], [cFullName], [cMemo], [dAddTime]) VALUES (10, N'2776', N'14.01.04.002', N'Touran右三角窗玻璃', N'1TO 845 412A', N'自制半成品_侧窗玻璃_清洁装箱_Touran右三角窗玻璃', N'', CAST(N'2016-02-21 14:32:41.137' AS DateTime))
SET IDENTITY_INSERT [dbo].[Bom] OFF
SET IDENTITY_INSERT [dbo].[BomDetail] ON 

INSERT [dbo].[BomDetail] ([AutoID], [BomID], [cFitemID], [cInvCode], [cInvName], [iQuantity], [cUnitID], [cUnitName], [cInvStd], [cFullName], [cMemo], [dAddTime]) VALUES (1, 1, N'2494', N'11.01.039', N'原料', CAST(10.0000000000 AS Decimal(18, 10)), N'409', N'KG', N'', N'原材料_塑胶类_原料', NULL, NULL)
INSERT [dbo].[BomDetail] ([AutoID], [BomID], [cFitemID], [cInvCode], [cInvName], [iQuantity], [cUnitID], [cUnitName], [cInvStd], [cFullName], [cMemo], [dAddTime]) VALUES (2, 1, N'1981', N'10.01.01.05.330805965C', N'插板', CAST(20.0000000000 AS Decimal(18, 10)), N'419', N'PC', N'', N'成品_上海大众_Santana B2_发动机仓件_插板', NULL, NULL)
INSERT [dbo].[BomDetail] ([AutoID], [BomID], [cFitemID], [cInvCode], [cInvName], [iQuantity], [cUnitID], [cUnitName], [cInvStd], [cFullName], [cMemo], [dAddTime]) VALUES (3, 2, N'1982', N'10.01.02.02.33D845051', N'GP4后风窗玻璃总成', CAST(20.0000000000 AS Decimal(18, 10)), N'419', N'PC', N'', N'成品_上海大众_Santana Vista_风挡玻璃_GP4后风窗玻璃总成', NULL, NULL)
INSERT [dbo].[BomDetail] ([AutoID], [BomID], [cFitemID], [cInvCode], [cInvName], [iQuantity], [cUnitID], [cUnitName], [cInvStd], [cFullName], [cMemo], [dAddTime]) VALUES (4, 1, N'1980', N'10.01.01.05.330805961C', N'进气罩总成', CAST(20000000.0000000000 AS Decimal(18, 10)), N'419', N'PC', N'', N'成品_上海大众_Santana B2_发动机仓件_进气罩总成', NULL, NULL)
INSERT [dbo].[BomDetail] ([AutoID], [BomID], [cFitemID], [cInvCode], [cInvName], [iQuantity], [cUnitID], [cUnitName], [cInvStd], [cFullName], [cMemo], [dAddTime]) VALUES (5, 1, N'1984', N'10.01.02.02.33D845051B', N'Vista后风窗玻璃总成', CAST(20000000.0000000000 AS Decimal(18, 10)), N'419', N'PC', N'', N'成品_上海大众_Santana Vista_风挡玻璃_Vista后风窗玻璃总成', NULL, NULL)
INSERT [dbo].[BomDetail] ([AutoID], [BomID], [cFitemID], [cInvCode], [cInvName], [iQuantity], [cUnitID], [cUnitName], [cInvStd], [cFullName], [cMemo], [dAddTime]) VALUES (6, 3, N'1981', N'10.01.01.05.330805965C', N'插板', CAST(400.0000000000 AS Decimal(18, 10)), N'419', N'PC', N'', N'成品_上海大众_Santana B2_发动机仓件_插板', N'20', CAST(N'2016-01-12 20:58:14.433' AS DateTime))
INSERT [dbo].[BomDetail] ([AutoID], [BomID], [cFitemID], [cInvCode], [cInvName], [iQuantity], [cUnitID], [cUnitName], [cInvStd], [cFullName], [cMemo], [dAddTime]) VALUES (7, 3, N'2120', N'10.01.08.03.1Z18630453AU', N'内饰', CAST(4400.0000000000 AS Decimal(18, 10)), N'419', N'PC', N'', N'成品_上海大众_Octavia Mingrui_内饰件_内饰', N'210', CAST(N'2016-01-12 20:58:29.897' AS DateTime))
INSERT [dbo].[BomDetail] ([AutoID], [BomID], [cFitemID], [cInvCode], [cInvName], [iQuantity], [cUnitID], [cUnitName], [cInvStd], [cFullName], [cMemo], [dAddTime]) VALUES (8, 2, N'1990', N'10.01.02.02.33D845091B', N'Vista前风窗玻璃总成', CAST(200.0000000000 AS Decimal(18, 10)), N'419', N'PC', N'', N'成品_上海大众_Santana Vista_风挡玻璃_Vista前风窗玻璃总成', N'20', CAST(N'2016-01-12 20:58:55.557' AS DateTime))
INSERT [dbo].[BomDetail] ([AutoID], [BomID], [cFitemID], [cInvCode], [cInvName], [iQuantity], [cUnitID], [cUnitName], [cInvStd], [cFullName], [cMemo], [dAddTime]) VALUES (9, 2, N'1998', N'10.01.02.03.330863241EHCW', N'副仪表板总成', NULL, N'419', N'PC', N'', N'成品_上海大众_Santana Vista_内饰件_副仪表板总成', NULL, CAST(N'2016-01-12 20:59:00.330' AS DateTime))
INSERT [dbo].[BomDetail] ([AutoID], [BomID], [cFitemID], [cInvCode], [cInvName], [iQuantity], [cUnitID], [cUnitName], [cInvStd], [cFullName], [cMemo], [dAddTime]) VALUES (10, 6, N'2002', N'10.01.02.03.330863241EU71', N'副仪表板总成', CAST(20.0000000000 AS Decimal(18, 10)), N'419', N'PC', N'', N'成品_上海大众_Santana Vista_内饰件_副仪表板总成', N'20', CAST(N'2016-01-12 20:59:22.283' AS DateTime))
INSERT [dbo].[BomDetail] ([AutoID], [BomID], [cFitemID], [cInvCode], [cInvName], [iQuantity], [cUnitID], [cUnitName], [cInvStd], [cFullName], [cMemo], [dAddTime]) VALUES (11, 6, N'1992', N'10.01.02.03.330857961A041', N'烟灰缸', CAST(20.0000000000 AS Decimal(18, 10)), N'419', N'PC', N'', N'成品_上海大众_Santana Vista_内饰件_烟灰缸', N'20', CAST(N'2016-01-12 20:59:28.603' AS DateTime))
INSERT [dbo].[BomDetail] ([AutoID], [BomID], [cFitemID], [cInvCode], [cInvName], [iQuantity], [cUnitID], [cUnitName], [cInvStd], [cFullName], [cMemo], [dAddTime]) VALUES (12, 7, N'1993', N'10.01.02.03.330857961B041', N'烟灰缸', CAST(20.0000000000 AS Decimal(18, 10)), N'419', N'PC', N'', N'成品_上海大众_Santana Vista_内饰件_烟灰缸', NULL, CAST(N'2016-01-12 21:01:37.600' AS DateTime))
INSERT [dbo].[BomDetail] ([AutoID], [BomID], [cFitemID], [cInvCode], [cInvName], [iQuantity], [cUnitID], [cUnitName], [cInvStd], [cFullName], [cMemo], [dAddTime]) VALUES (13, 7, N'1994', N'10.01.02.03.330863241C232', N'副仪表板总成', CAST(20.0000000000 AS Decimal(18, 10)), N'419', N'PC', N'', N'成品_上海大众_Santana Vista_内饰件_副仪表板总成', NULL, CAST(N'2016-01-12 21:02:00.550' AS DateTime))
INSERT [dbo].[BomDetail] ([AutoID], [BomID], [cFitemID], [cInvCode], [cInvName], [iQuantity], [cUnitID], [cUnitName], [cInvStd], [cFullName], [cMemo], [dAddTime]) VALUES (14, 8, N'2122', N'10.01.08.03.1Z186304562U', N'内饰', CAST(20.0000000000 AS Decimal(18, 10)), N'419', N'PC', N'', N'成品_上海大众_Octavia Mingrui_内饰件_内饰', N'20', CAST(N'2016-01-13 23:04:49.513' AS DateTime))
INSERT [dbo].[BomDetail] ([AutoID], [BomID], [cFitemID], [cInvCode], [cInvName], [iQuantity], [cUnitID], [cUnitName], [cInvStd], [cFullName], [cMemo], [dAddTime]) VALUES (15, 9, N'2468', N'11.01.013', N'原料', CAST(0.1425000000 AS Decimal(18, 10)), N'409', N'', N'', N'原材料_塑胶类_原料', NULL, CAST(N'2016-01-16 10:14:22.690' AS DateTime))
INSERT [dbo].[BomDetail] ([AutoID], [BomID], [cFitemID], [cInvCode], [cInvName], [iQuantity], [cUnitID], [cUnitName], [cInvStd], [cFullName], [cMemo], [dAddTime]) VALUES (16, 9, N'2502', N'13.01.0018', N'Touran前侧窗玻璃', CAST(1.0000000000 AS Decimal(18, 10)), N'419', N'', N'', N'外购外协件_侧窗玻璃_Touran前侧窗玻璃', NULL, CAST(N'2016-01-16 10:14:42.953' AS DateTime))
INSERT [dbo].[BomDetail] ([AutoID], [BomID], [cFitemID], [cInvCode], [cInvName], [iQuantity], [cUnitID], [cUnitName], [cInvStd], [cFullName], [cMemo], [dAddTime]) VALUES (17, 9, N'2980', N'16.03.002', N'胶水', CAST(0.0064000000 AS Decimal(18, 10)), N'409', N'', N'', N'辅助材料_胶水_胶水', NULL, CAST(N'2016-01-16 10:15:00.970' AS DateTime))
INSERT [dbo].[BomDetail] ([AutoID], [BomID], [cFitemID], [cInvCode], [cInvName], [iQuantity], [cUnitID], [cUnitName], [cInvStd], [cFullName], [cMemo], [dAddTime]) VALUES (18, 9, N'2991', N'16.04.001', N'固化剂', CAST(0.4000000000 AS Decimal(18, 10)), N'409', N'', N'', N'辅助材料_固化剂_固化剂', NULL, CAST(N'2016-01-16 10:15:38.410' AS DateTime))
INSERT [dbo].[BomDetail] ([AutoID], [BomID], [cFitemID], [cInvCode], [cInvName], [iQuantity], [cUnitID], [cUnitName], [cInvStd], [cFullName], [cMemo], [dAddTime]) VALUES (19, 9, N'2518', N'13.01.0038', N'螺钉总成', CAST(1.0000000000 AS Decimal(18, 10)), N'419', N'', N'', N'外购外协件_侧窗玻璃_螺钉总成', NULL, CAST(N'2016-01-16 10:15:53.323' AS DateTime))
INSERT [dbo].[BomDetail] ([AutoID], [BomID], [cFitemID], [cInvCode], [cInvName], [iQuantity], [cUnitID], [cUnitName], [cInvStd], [cFullName], [cMemo], [dAddTime]) VALUES (20, 10, N'1975', N'10.01.01.05.330080058', N'插板', CAST(20.0000000000 AS Decimal(18, 10)), N'419', N'PC', N'', N'成品_上海大众_Santana B2_发动机仓件_插板', NULL, CAST(N'2016-02-21 14:32:24.600' AS DateTime))
INSERT [dbo].[BomDetail] ([AutoID], [BomID], [cFitemID], [cInvCode], [cInvName], [iQuantity], [cUnitID], [cUnitName], [cInvStd], [cFullName], [cMemo], [dAddTime]) VALUES (21, 10, N'1976', N'10.01.01.05.330121293', N'空气导流板', CAST(20.0000000000 AS Decimal(18, 10)), N'419', N'PC', N'', N'成品_上海大众_Santana B2_发动机仓件_空气导流板', NULL, CAST(N'2016-02-21 14:32:27.350' AS DateTime))
INSERT [dbo].[BomDetail] ([AutoID], [BomID], [cFitemID], [cInvCode], [cInvName], [iQuantity], [cUnitID], [cUnitName], [cInvStd], [cFullName], [cMemo], [dAddTime]) VALUES (22, 10, N'1980', N'10.01.01.05.330805961C', N'进气罩总成', CAST(2.0000000000 AS Decimal(18, 10)), N'419', N'PC', N'', N'成品_上海大众_Santana B2_发动机仓件_进气罩总成', NULL, CAST(N'2016-02-21 14:32:29.917' AS DateTime))
SET IDENTITY_INSERT [dbo].[BomDetail] OFF
SET IDENTITY_INSERT [dbo].[BRole] ON 

INSERT [dbo].[BRole] ([ID], [cCode], [cName], [dAddTime], [bEnable]) VALUES (1, N'01', N'Admin', CAST(N'2016-01-09 14:34:14.300' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[BRole] OFF
SET IDENTITY_INSERT [dbo].[BRoleFunction] ON 

INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (1, N'01', N'原料标签打印', 1)
INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (2, N'01', N'金蝶采购订单', 1)
INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (3, N'01', N'产成品BOM管理', 1)
INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (4, N'01', N'产成品BOM查询', 1)
INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (5, N'01', N'班次制令单', 1)
INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (6, N'01', N'产成品标签打印', 1)
INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (7, N'01', N'产成品拆箱', 1)
INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (8, N'01', N'产成品出库指令单', 1)
INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (9, N'01', N'打印调拨单', 1)
INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (10, N'01', N'打印盘点单', 1)
INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (11, N'01', N'原料标签打印记录表', 1)
INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (12, N'01', N'原料采购入库明细表', 1)
INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (13, N'01', N'用户管理', 1)
INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (14, N'01', N'角色权限管理', 1)
INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (15, N'01', N'表格样式维护', 1)
INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (16, N'demo', N'原料标签打印', NULL)
INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (17, N'demo', N'金蝶采购订单', NULL)
INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (18, N'demo', N'产成品BOM管理', NULL)
INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (19, N'demo', N'产成品BOM查询', NULL)
INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (20, N'demo', N'班次制令单', NULL)
INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (21, N'demo', N'产成品标签打印', NULL)
INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (22, N'demo', N'产成品拆箱', NULL)
INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (23, N'demo', N'产成品出库指令单', NULL)
INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (24, N'demo', N'打印调拨单', NULL)
INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (25, N'demo', N'打印盘点单', NULL)
INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (26, N'demo', N'原料标签打印记录表', NULL)
INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (27, N'demo', N'原料采购入库明细表', NULL)
INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (28, N'demo', N'用户管理', NULL)
INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (29, N'demo', N'角色权限管理', NULL)
INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (30, N'demo', N'表格样式维护', NULL)
INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (31, N'01', N'标签模版维护', 1)
INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (32, N'demo', N'标签模版维护', NULL)
INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (33, N'01', N'产成品标签打印记录表', 1)
INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (34, N'01', N'产成品追溯表', 1)
INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (35, N'01', N'原料批次追溯', 1)
INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (36, N'demo', N'产成品标签打印记录表', NULL)
INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (37, N'demo', N'产成品追溯表', NULL)
INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (38, N'demo', N'原料批次追溯', NULL)
INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (39, N'demo', N'仓位标签打印', NULL)
INSERT [dbo].[BRoleFunction] ([ID], [rCode], [fCode], [bRight]) VALUES (40, N'01', N'仓位标签打印', 1)
SET IDENTITY_INSERT [dbo].[BRoleFunction] OFF
SET IDENTITY_INSERT [dbo].[BTempletList] ON 

INSERT [dbo].[BTempletList] ([ID], [cFunction], [cCaption], [cTempletPath], [cPrinter], [bDefault], [dAddTime]) VALUES (1, N'原料标签', N'原料标准标签', N'原料标准标签.repx', N'Adobe PDF', 1, NULL)
INSERT [dbo].[BTempletList] ([ID], [cFunction], [cCaption], [cTempletPath], [cPrinter], [bDefault], [dAddTime]) VALUES (2, N'产成品标签', N'产成品标准标签', N'产成品标准标签.repx', N'Adobe PDF', 1, NULL)
INSERT [dbo].[BTempletList] ([ID], [cFunction], [cCaption], [cTempletPath], [cPrinter], [bDefault], [dAddTime]) VALUES (3, N'班次制单模板', N'班次制令单', N'班次制令单.repx', N'Adobe PDF', 1, NULL)
INSERT [dbo].[BTempletList] ([ID], [cFunction], [cCaption], [cTempletPath], [cPrinter], [bDefault], [dAddTime]) VALUES (4, N'仓位标签', N'仓位标签', N'E:\Git Project\JWMSH\JWMSH\JWMSH\JWMSH\bin\debug\Label\产成品标准标签.repx', N'Adobe PDF', 1, NULL)
SET IDENTITY_INSERT [dbo].[BTempletList] OFF
SET IDENTITY_INSERT [dbo].[BUser] ON 

INSERT [dbo].[BUser] ([ID], [uCode], [uName], [uPassword], [uRole], [uDepartment], [dAddTime], [bEnable], [bOperator]) VALUES (1, N'demo', N'Demo', N'a994daa0c4a76b6a4ef640d41777ec0a', N'01', N'D001', CAST(N'2016-01-09 14:33:28.110' AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[BUser] OFF
SET IDENTITY_INSERT [dbo].[ColumnSeting] ON 

INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (1, N'-876654441', N'金蝶物料档案', N'FItemID', N'KID', 0, 0, 68)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (2, N'-876654441', N'金蝶物料档案', N'FNumber', N'编码', 1, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (3, N'-876654441', N'金蝶物料档案', N'FName', N'名称', 2, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (4, N'-876654441', N'金蝶物料档案', N'FModel', N'型号', 3, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (5, N'-876654441', N'金蝶物料档案', N'FFullName', N'全称', 4, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (6, N'-876654441', N'金蝶物料档案', N'FDefaultLoc', N'默认仓库', 5, 0, 85)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (7, N'-876654441', N'金蝶物料档案', N'FSPID', N'默认仓位', 6, 0, 68)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (8, N'269846084', N'原料标签打印', N'AutoID', N'AutoID', 0, 1, 93)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (9, N'269846084', N'原料标签打印', N'cSerialNumber', N'序列号', 3, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (10, N'269846084', N'原料标签打印', N'FitemID', N'FitemID', 1, 1, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (11, N'269846084', N'原料标签打印', N'cInvCode', N'编码', 2, 0, 77)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (12, N'269846084', N'原料标签打印', N'cInvName', N'名称', 6, 0, 132)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (13, N'269846084', N'原料标签打印', N'cInvStd', N'规格', 7, 0, 101)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (14, N'269846084', N'原料标签打印', N'cFullName', N'全称', 8, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (15, N'269846084', N'原料标签打印', N'cDefaultLoc', N'默认仓库', 9, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (16, N'269846084', N'原料标签打印', N'cDefaultSP', N'默认仓位', 10, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (17, N'269846084', N'原料标签打印', N'cLotNo', N'批号', 4, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (18, N'269846084', N'原料标签打印', N'cVendor', N'供应商', 11, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (19, N'269846084', N'原料标签打印', N'iQuantity', N'数量', 5, 0, 93)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (20, N'269846084', N'原料标签打印', N'dDate', N'生产日期', 12, 0, 94)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (21, N'269846084', N'原料标签打印', N'cMemo', N'备注', 15, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (22, N'269846084', N'原料标签打印', N'cDefine1', N'供应商批号', 13, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (23, N'269846084', N'原料标签打印', N'cDefine2', N'cDefine2', 14, 1, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (24, N'269846084', N'原料标签打印', N'cDefine3', N'cDefine3', 16, 1, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (25, N'269846084', N'原料标签打印', N'cDefine4', N'cDefine4', 17, 1, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (26, N'-416220480', N'产成品追溯表', N'AutoID', N'AutoID', 0, 1, 93)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (27, N'-416220480', N'产成品追溯表', N'cSerialNumber', N'制令单号', 2, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (28, N'-416220480', N'产成品追溯表', N'cBarCode', N'条码号', 3, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (29, N'-416220480', N'产成品追溯表', N'iQuantity', N'数量', 5, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (30, N'-416220480', N'产成品追溯表', N'cDefine1', N'cDefine1', 6, 1, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (31, N'-416220480', N'产成品追溯表', N'cDefine2', N'cDefine2', 7, 1, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (32, N'-416220480', N'产成品追溯表', N'cDefine3', N'cDefine3', 9, 1, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (33, N'-416220480', N'产成品追溯表', N'cDefine4', N'cDefine4', 11, 1, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (34, N'-416220480', N'产成品追溯表', N'cMemo', N'备注', 14, 0, 122)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (35, N'-416220480', N'产成品追溯表', N'BomID', N'BomID', 13, 1, 97)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (36, N'-416220480', N'产成品追溯表', N'cFitemID', N'cFitemID', 4, 1, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (37, N'-416220480', N'产成品追溯表', N'cInvCode', N'产品编码', 1, 0, 170)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (38, N'-416220480', N'产成品追溯表', N'cInvName', N'产品名称', 8, 0, 132)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (39, N'-416220480', N'产成品追溯表', N'cInvStd', N'产品规格', 10, 0, 101)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (40, N'-416220480', N'产成品追溯表', N'cFullName', N'全称', 12, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (41, N'-416220480', N'产成品追溯表', N'cOrderNumber', N'客户订单号', 15, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (42, N'-416220480', N'产成品追溯表', N'iSheduleQty', N'生产计划', 16, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (43, N'-416220480', N'产成品追溯表', N'dDate', N'生产日期', 18, 0, 122)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (44, N'-416220480', N'产成品追溯表', N'iSheduleMemo', N'制令单备注', 19, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (45, N'-416220480', N'产成品追溯表', N'cDeptName', N'部门', 20, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (46, N'-416220480', N'产成品追溯表', N'dAddTime', N'生成时间', 17, 0, 97)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (47, N'-416220480', N'产成品追溯表', N'View_ProductLabel_ShiftDetail', N'View_ProductLabel_ShiftDetail', 21, 1, 196)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (48, N'-876654441', N'金蝶物料档案', N'FUnitID', N'计量单位ID', 7, 0, 68)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (49, N'-876654441', N'金蝶物料档案', N'FUnitName', N'计量单位', 8, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (50, N'-1503720452', N'产成品标签打印记录表', N'AutoID', N'AutoID', 0, 1, 93)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (51, N'-1503720452', N'产成品标签打印记录表', N'cSerialNumber', N'序列号', 2, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (52, N'-1503720452', N'产成品标签打印记录表', N'cBarCode', N'产成品条码号', 3, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (53, N'-1503720452', N'产成品标签打印记录表', N'iQuantity', N'数量', 4, 0, 68)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (54, N'-1503720452', N'产成品标签打印记录表', N'cDefine1', N'cDefine1', 5, 1, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (55, N'-1503720452', N'产成品标签打印记录表', N'cDefine2', N'cDefine2', 6, 1, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (56, N'-1503720452', N'产成品标签打印记录表', N'cDefine3', N'cDefine3', 8, 1, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (57, N'-1503720452', N'产成品标签打印记录表', N'cDefine4', N'cDefine4', 10, 1, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (58, N'-1503720452', N'产成品标签打印记录表', N'cMemo', N'备注', 16, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (59, N'-1503720452', N'产成品标签打印记录表', N'BomID', N'BomID', 11, 0, 93)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (60, N'-1503720452', N'产成品标签打印记录表', N'cFitemID', N'cFitemID', 12, 0, 68)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (61, N'-1503720452', N'产成品标签打印记录表', N'cInvCode', N'产品编码', 1, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (62, N'-1503720452', N'产成品标签打印记录表', N'cInvName', N'产品名称', 7, 0, 132)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (63, N'-1503720452', N'产成品标签打印记录表', N'cInvStd', N'产品规格', 9, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (64, N'-1503720452', N'产成品标签打印记录表', N'cFullName', N'产成品全称', 14, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (65, N'-1503720452', N'产成品标签打印记录表', N'cOrderNumber', N'客户订单号', 15, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (66, N'-1503720452', N'产成品标签打印记录表', N'iSheduleQty', N'计划数量', 17, 0, 85)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (67, N'-1503720452', N'产成品标签打印记录表', N'dDate', N'生产日期', 13, 0, 94)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (68, N'-1503720452', N'产成品标签打印记录表', N'iSheduleMemo', N'计划订单备注', 18, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (69, N'-1503720452', N'产成品标签打印记录表', N'cDeptName', N'部门名称', 19, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (70, N'-1503720452', N'产成品标签打印记录表', N'dAddTime', N'添加时间', 20, 0, 94)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (71, N'-839180249', N'原料标签打印记录表', N'AutoID', N'AutoID', 0, 1, 93)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (72, N'-839180249', N'原料标签打印记录表', N'cSerialNumber', N'序列号', 3, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (73, N'-839180249', N'原料标签打印记录表', N'FitemID', N'物料编码', 2, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (74, N'-839180249', N'原料标签打印记录表', N'cInvCode', N'产品编码', 1, 0, 77)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (75, N'-839180249', N'原料标签打印记录表', N'cInvName', N'产品名称', 6, 0, 132)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (76, N'-839180249', N'原料标签打印记录表', N'cInvStd', N'产品规格', 7, 0, 101)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (77, N'-839180249', N'原料标签打印记录表', N'cFullName', N'cFullName', 8, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (78, N'-839180249', N'原料标签打印记录表', N'cDefaultLoc', N'cDefaultLoc', 9, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (79, N'-839180249', N'原料标签打印记录表', N'cDefaultSP', N'cDefaultSP', 10, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (80, N'-839180249', N'原料标签打印记录表', N'cLotNo', N'批号', 4, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (81, N'-839180249', N'原料标签打印记录表', N'cVendor', N'供应商', 11, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (82, N'-839180249', N'原料标签打印记录表', N'iQuantity', N'数量', 5, 0, 93)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (83, N'-839180249', N'原料标签打印记录表', N'dDate', N'生产日期', 12, 0, 94)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (84, N'-839180249', N'原料标签打印记录表', N'cMemo', N'备注', 15, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (85, N'-839180249', N'原料标签打印记录表', N'cDefine1', N'cDefine1', 13, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (86, N'-839180249', N'原料标签打印记录表', N'cDefine2', N'cDefine2', 14, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (87, N'-839180249', N'原料标签打印记录表', N'cDefine3', N'cDefine3', 16, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (88, N'-839180249', N'原料标签打印记录表', N'cDefine4', N'cDefine4', 17, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (89, N'1726756816', N'产成品BOM查询', N'AutoID', N'AutoID', 0, 1, 93)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (90, N'1726756816', N'产成品BOM查询', N'cFitemID', N'cFitemID', 1, 1, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (91, N'1726756816', N'产成品BOM查询', N'cInvCode', N'产品编码', 2, 0, 170)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (92, N'1726756816', N'产成品BOM查询', N'cInvName', N'产品名称', 3, 0, 256)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (93, N'1726756816', N'产成品BOM查询', N'cInvStd', N'产品规格', 5, 0, 113)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (94, N'1726756816', N'产成品BOM查询', N'cFullName', N'产成品全称', 4, 0, 348)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (95, N'1726756816', N'产成品BOM查询', N'cMemo', N'备注', 7, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (96, N'1726756816', N'产成品BOM查询', N'dAddTime', N'添加时间', 6, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (97, N'-1640528073', N'班次制令单选料', N'FItemID', N'物料ID', 0, 1, 68)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (98, N'-1640528073', N'班次制令单选料', N'FNumber', N'物料编码', 1, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (99, N'-1640528073', N'班次制令单选料', N'FName', N'物料名称', 2, 0, 118)
GO
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (100, N'-1640528073', N'班次制令单选料', N'Quantity', N'数量', 3, 0, 113)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (101, N'-1640528073', N'班次制令单选料', N'FModel', N'规格', 4, 0, 101)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (102, N'-1640528073', N'班次制令单选料', N'FFullName', N'全称', 5, 0, 264)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (103, N'-1640528073', N'班次制令单选料', N'FBatchNo', N'批次', 6, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (104, N'-1640528073', N'班次制令单选料', N'FStockID', N'仓库', 7, 0, 68)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (105, N'-1640528073', N'班次制令单选料', N'FStockNumber', N'仓库编码', 8, 0, 82)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (106, N'-1640528073', N'班次制令单选料', N'FStockName', N'仓库名称', 9, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (107, N'-1640528073', N'班次制令单选料', N'FStockPlaceID', N'仓位ID', 10, 0, 97)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (108, N'-1640528073', N'班次制令单选料', N'FStockPlaceNumber', N'仓位编码', 11, 0, 122)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (109, N'-1640528073', N'班次制令单选料', N'FStockPlaceName', N'仓位名称', 12, 0, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (110, N'-625597659', N'表格样式维护', N'ID', N'ID', 0, 1, 68)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (111, N'-625597659', N'表格样式维护', N'cFormID', N'cFormID', 1, 1, 118)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (112, N'-625597659', N'表格样式维护', N'cFormName', N'窗体名称', 2, 0, 231)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (113, N'-625597659', N'表格样式维护', N'cKey', N'列索引', 3, 0, 189)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (114, N'-625597659', N'表格样式维护', N'cCaption', N'列标题', 4, 0, 309)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (115, N'-625597659', N'表格样式维护', N'iVisualPosition', N'显示位置', 5, 1, 68)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (116, N'-625597659', N'表格样式维护', N'bHide', N'是否隐藏', 6, 0, 66)
INSERT [dbo].[ColumnSeting] ([ID], [cFormID], [cFormName], [cKey], [cCaption], [iVisualPosition], [bHide], [iWidth]) VALUES (117, N'-625597659', N'表格样式维护', N'iWidth', N'宽度', 7, 0, 68)
SET IDENTITY_INSERT [dbo].[ColumnSeting] OFF
SET IDENTITY_INSERT [dbo].[ProductLabel] ON 

INSERT [dbo].[ProductLabel] ([AutoID], [cSerialNumber], [cBarCode], [iQuantity], [cDefine1], [cDefine2], [cDefine3], [cDefine4], [cMemo]) VALUES (1, N'SF1601140005', N'SF16011400050001', 100, N'', N'', N'', N'', N'1010')
INSERT [dbo].[ProductLabel] ([AutoID], [cSerialNumber], [cBarCode], [iQuantity], [cDefine1], [cDefine2], [cDefine3], [cDefine4], [cMemo]) VALUES (2, N'SF1601140005', N'SF16011400050002', 100, N'', N'', N'', N'', N'1010')
INSERT [dbo].[ProductLabel] ([AutoID], [cSerialNumber], [cBarCode], [iQuantity], [cDefine1], [cDefine2], [cDefine3], [cDefine4], [cMemo]) VALUES (3, N'SF1601140005', N'SF16011400050003', 100, N'', N'', N'', N'', N'1010')
INSERT [dbo].[ProductLabel] ([AutoID], [cSerialNumber], [cBarCode], [iQuantity], [cDefine1], [cDefine2], [cDefine3], [cDefine4], [cMemo]) VALUES (4, N'SF1601140005', N'SF16011400050004', 100, N'', N'', N'', N'', N'1010')
INSERT [dbo].[ProductLabel] ([AutoID], [cSerialNumber], [cBarCode], [iQuantity], [cDefine1], [cDefine2], [cDefine3], [cDefine4], [cMemo]) VALUES (5, N'SF1601140005', N'SF16011400050005', 100, N'', N'', N'', N'', N'1010')
INSERT [dbo].[ProductLabel] ([AutoID], [cSerialNumber], [cBarCode], [iQuantity], [cDefine1], [cDefine2], [cDefine3], [cDefine4], [cMemo]) VALUES (6, N'SF1601140005', N'SF16011400050006', 100, N'', N'', N'', N'', N'1010')
INSERT [dbo].[ProductLabel] ([AutoID], [cSerialNumber], [cBarCode], [iQuantity], [cDefine1], [cDefine2], [cDefine3], [cDefine4], [cMemo]) VALUES (7, N'SF1601140005', N'SF16011400050007', 100, N'', N'', N'', N'', N'1010')
INSERT [dbo].[ProductLabel] ([AutoID], [cSerialNumber], [cBarCode], [iQuantity], [cDefine1], [cDefine2], [cDefine3], [cDefine4], [cMemo]) VALUES (8, N'SF1601140005', N'SF16011400050008', 100, N'', N'', N'', N'', N'1010')
INSERT [dbo].[ProductLabel] ([AutoID], [cSerialNumber], [cBarCode], [iQuantity], [cDefine1], [cDefine2], [cDefine3], [cDefine4], [cMemo]) VALUES (9, N'SF1601140005', N'SF16011400050009', 100, N'', N'', N'', N'', N'1010')
INSERT [dbo].[ProductLabel] ([AutoID], [cSerialNumber], [cBarCode], [iQuantity], [cDefine1], [cDefine2], [cDefine3], [cDefine4], [cMemo]) VALUES (10, N'SF1601140005', N'SF16011400050010', 100, N'', N'', N'', N'', N'1010')
INSERT [dbo].[ProductLabel] ([AutoID], [cSerialNumber], [cBarCode], [iQuantity], [cDefine1], [cDefine2], [cDefine3], [cDefine4], [cMemo]) VALUES (11, N'SF1601140005', N'SF16011400050011', 10, N'', N'', N'', N'', N'0001')
INSERT [dbo].[ProductLabel] ([AutoID], [cSerialNumber], [cBarCode], [iQuantity], [cDefine1], [cDefine2], [cDefine3], [cDefine4], [cMemo]) VALUES (12, N'SF1601140005', N'SF16011400050012', 10, N'', N'', N'', N'', N'0001')
INSERT [dbo].[ProductLabel] ([AutoID], [cSerialNumber], [cBarCode], [iQuantity], [cDefine1], [cDefine2], [cDefine3], [cDefine4], [cMemo]) VALUES (13, N'SF1601140005', N'SF16011400050013', 10, N'', N'', N'', N'', N'0001')
INSERT [dbo].[ProductLabel] ([AutoID], [cSerialNumber], [cBarCode], [iQuantity], [cDefine1], [cDefine2], [cDefine3], [cDefine4], [cMemo]) VALUES (14, N'SF1601140005', N'SF16011400050014', 10, N'', N'', N'', N'', N'0001')
INSERT [dbo].[ProductLabel] ([AutoID], [cSerialNumber], [cBarCode], [iQuantity], [cDefine1], [cDefine2], [cDefine3], [cDefine4], [cMemo]) VALUES (15, N'SF1601140005', N'SF16011400050015', 10, N'', N'', N'', N'', N'0001')
INSERT [dbo].[ProductLabel] ([AutoID], [cSerialNumber], [cBarCode], [iQuantity], [cDefine1], [cDefine2], [cDefine3], [cDefine4], [cMemo]) VALUES (16, N'SF1601140005', N'SF16011400050016', 10, N'', N'', N'', N'', N'0001')
INSERT [dbo].[ProductLabel] ([AutoID], [cSerialNumber], [cBarCode], [iQuantity], [cDefine1], [cDefine2], [cDefine3], [cDefine4], [cMemo]) VALUES (17, N'SF1601140005', N'SF16011400050017', 10, N'', N'', N'', N'', N'0001')
INSERT [dbo].[ProductLabel] ([AutoID], [cSerialNumber], [cBarCode], [iQuantity], [cDefine1], [cDefine2], [cDefine3], [cDefine4], [cMemo]) VALUES (18, N'SF1601140005', N'SF16011400050018', 10, N'', N'', N'', N'', N'0001')
INSERT [dbo].[ProductLabel] ([AutoID], [cSerialNumber], [cBarCode], [iQuantity], [cDefine1], [cDefine2], [cDefine3], [cDefine4], [cMemo]) VALUES (19, N'SF1601140005', N'SF16011400050019', 10, N'', N'', N'', N'', N'0001')
INSERT [dbo].[ProductLabel] ([AutoID], [cSerialNumber], [cBarCode], [iQuantity], [cDefine1], [cDefine2], [cDefine3], [cDefine4], [cMemo]) VALUES (20, N'SF1601140005', N'SF16011400050020', 10, N'', N'', N'', N'', N'0001')
INSERT [dbo].[ProductLabel] ([AutoID], [cSerialNumber], [cBarCode], [iQuantity], [cDefine1], [cDefine2], [cDefine3], [cDefine4], [cMemo]) VALUES (21, N'SF1601160001', N'SF16011600010001', 10, N'', N'', N'', N'', N'TEST')
INSERT [dbo].[ProductLabel] ([AutoID], [cSerialNumber], [cBarCode], [iQuantity], [cDefine1], [cDefine2], [cDefine3], [cDefine4], [cMemo]) VALUES (22, N'SF1601160001', N'SF16011600010002', 10, N'', N'', N'', N'', N'TEST')
INSERT [dbo].[ProductLabel] ([AutoID], [cSerialNumber], [cBarCode], [iQuantity], [cDefine1], [cDefine2], [cDefine3], [cDefine4], [cMemo]) VALUES (23, N'SF1601160001', N'SF16011600010003', 10, N'', N'', N'', N'', N'TEST')
INSERT [dbo].[ProductLabel] ([AutoID], [cSerialNumber], [cBarCode], [iQuantity], [cDefine1], [cDefine2], [cDefine3], [cDefine4], [cMemo]) VALUES (24, N'SF1601160001', N'SF16011600010004', 10, N'', N'', N'', N'', N'TEST')
INSERT [dbo].[ProductLabel] ([AutoID], [cSerialNumber], [cBarCode], [iQuantity], [cDefine1], [cDefine2], [cDefine3], [cDefine4], [cMemo]) VALUES (25, N'SF1601160001', N'SF16011600010005', 10, N'', N'', N'', N'', N'TEST')
INSERT [dbo].[ProductLabel] ([AutoID], [cSerialNumber], [cBarCode], [iQuantity], [cDefine1], [cDefine2], [cDefine3], [cDefine4], [cMemo]) VALUES (26, N'SF1601160001', N'SF16011600010006', 10, N'', N'', N'', N'', N'TEST')
INSERT [dbo].[ProductLabel] ([AutoID], [cSerialNumber], [cBarCode], [iQuantity], [cDefine1], [cDefine2], [cDefine3], [cDefine4], [cMemo]) VALUES (27, N'SF1601160001', N'SF16011600010007', 10, N'', N'', N'', N'', N'TEST')
INSERT [dbo].[ProductLabel] ([AutoID], [cSerialNumber], [cBarCode], [iQuantity], [cDefine1], [cDefine2], [cDefine3], [cDefine4], [cMemo]) VALUES (28, N'SF1601160001', N'SF16011600010008', 10, N'', N'', N'', N'', N'TEST')
INSERT [dbo].[ProductLabel] ([AutoID], [cSerialNumber], [cBarCode], [iQuantity], [cDefine1], [cDefine2], [cDefine3], [cDefine4], [cMemo]) VALUES (29, N'SF1601160001', N'SF16011600010009', 10, N'', N'', N'', N'', N'TEST')
INSERT [dbo].[ProductLabel] ([AutoID], [cSerialNumber], [cBarCode], [iQuantity], [cDefine1], [cDefine2], [cDefine3], [cDefine4], [cMemo]) VALUES (30, N'SF1601160001', N'SF16011600010010', 10, N'', N'', N'', N'', N'TEST')
INSERT [dbo].[ProductLabel] ([AutoID], [cSerialNumber], [cBarCode], [iQuantity], [cDefine1], [cDefine2], [cDefine3], [cDefine4], [cMemo]) VALUES (31, N'SF1602210001', N'SF16022100010001', 1, N'', N'', N'', N'', N'')
SET IDENTITY_INSERT [dbo].[ProductLabel] OFF
SET IDENTITY_INSERT [dbo].[Rm_Po] ON 

INSERT [dbo].[Rm_Po] ([AutoID], [cOrderNumber], [cInvCode], [cInvName], [cUnit], [iQuantity], [iScanQuantity], [cVendor], [cMemo], [dDate], [cUser], [cGuid], [FEntryID], [FItemID]) VALUES (1, N'DZLX-CGDD20150630-04', N'0280', N'W77左后侧窗玻璃', N'1', CAST(2100.0000 AS Decimal(18, 4)), CAST(3000.0000 AS Decimal(18, 4)), N'福耀集团（上海）汽车玻璃有限公司', N'', CAST(N'2016-02-28 16:10:08.793' AS DateTime), N'Demo', N'4dec5674-f365-4061-8d5d-dd85e9a2bfcc', 1, 4134)
INSERT [dbo].[Rm_Po] ([AutoID], [cOrderNumber], [cInvCode], [cInvName], [cUnit], [iQuantity], [iScanQuantity], [cVendor], [cMemo], [dDate], [cUser], [cGuid], [FEntryID], [FItemID]) VALUES (2, N'DZLX-CGDD20150630-04', N'0281', N'W77右后侧窗玻璃', N'1', CAST(2400.0000 AS Decimal(18, 4)), CAST(2400.0000 AS Decimal(18, 4)), N'福耀集团（上海）汽车玻璃有限公司', N'', CAST(N'2016-02-28 16:10:09.477' AS DateTime), N'Demo', N'4dec5674-f365-4061-8d5d-dd85e9a2bfcc', 2, 4135)
SET IDENTITY_INSERT [dbo].[Rm_Po] OFF
SET IDENTITY_INSERT [dbo].[Rm_StoreDetail] ON 

INSERT [dbo].[Rm_StoreDetail] ([AutoID], [cSerialNumber], [cLotNo], [cOrderNumber], [cInvCode], [cInvName], [cUnit], [iQuantity], [dDate], [dScanTime], [cUser], [cGuid], [FEntryID], [FSPNumber], [FitemID]) VALUES (1, N'RM1602280002;2016/2/28', N'w1511190102', N'DZLX-CGDD20150630-04', N'0281', N'W77右后侧窗玻璃', NULL, CAST(2400.0000 AS Decimal(18, 4)), CAST(N'2016-02-28 16:10:06.247' AS DateTime), CAST(N'2016-02-28 16:10:01.000' AS DateTime), N'Demo', N'4dec5674-f365-4061-8d5d-dd85e9a2bfcc', 2, N'YG-3-10', 4135)
INSERT [dbo].[Rm_StoreDetail] ([AutoID], [cSerialNumber], [cLotNo], [cOrderNumber], [cInvCode], [cInvName], [cUnit], [iQuantity], [dDate], [dScanTime], [cUser], [cGuid], [FEntryID], [FSPNumber], [FitemID]) VALUES (2, N'RM1602280001;2016/2/28', N'w1512180101', N'DZLX-CGDD20150630-04', N'0280', N'W77左后侧窗玻璃', NULL, CAST(1000.0000 AS Decimal(18, 4)), CAST(N'2016-02-28 16:10:07.227' AS DateTime), CAST(N'2016-02-28 16:09:12.000' AS DateTime), N'Demo', N'4dec5674-f365-4061-8d5d-dd85e9a2bfcc', 1, N'YG-3-10', NULL)
INSERT [dbo].[Rm_StoreDetail] ([AutoID], [cSerialNumber], [cLotNo], [cOrderNumber], [cInvCode], [cInvName], [cUnit], [iQuantity], [dDate], [dScanTime], [cUser], [cGuid], [FEntryID], [FSPNumber], [FitemID]) VALUES (3, N'RM1602280001;2016/2/28', N'w1512180101', N'DZLX-CGDD20150630-04', N'0280', N'W77左后侧窗玻璃', NULL, CAST(2000.0000 AS Decimal(18, 4)), CAST(N'2016-02-28 16:10:08.330' AS DateTime), CAST(N'2016-02-28 16:08:53.000' AS DateTime), N'Demo', N'4dec5674-f365-4061-8d5d-dd85e9a2bfcc', 1, N'YG-3-10', 4134)
SET IDENTITY_INSERT [dbo].[Rm_StoreDetail] OFF
SET IDENTITY_INSERT [dbo].[RmLabel] ON 

INSERT [dbo].[RmLabel] ([AutoID], [cSerialNumber], [FitemID], [cInvCode], [cInvName], [cInvStd], [cFullName], [cDefaultLoc], [cDefaultSP], [cLotNo], [cVendor], [iQuantity], [dDate], [cMemo], [cDefine1], [cDefine2], [cDefine3], [cDefine4]) VALUES (1, N'RM1601100001', N'1975', N'10.01.01.05.330080058', N'插板', N'1', N'成品_上海大众_Santana B2_发动机仓件_插板', N'0', N'0', N'S2012', N'1', CAST(123.0000 AS Decimal(18, 4)), CAST(N'2016-01-10' AS Date), N'1', N'', N'', N'', N'')
INSERT [dbo].[RmLabel] ([AutoID], [cSerialNumber], [FitemID], [cInvCode], [cInvName], [cInvStd], [cFullName], [cDefaultLoc], [cDefaultSP], [cLotNo], [cVendor], [iQuantity], [dDate], [cMemo], [cDefine1], [cDefine2], [cDefine3], [cDefine4]) VALUES (2, N'RM1601100002', N'1977', N'10.01.01.05.330121407', N'补偿容器', N'330 121 407', N'成品_上海大众_Santana B2_发动机仓件_补偿容器', N'0', N'0', N'S00220', N'上海桃柯贸易有限公司', CAST(2032.0000 AS Decimal(18, 4)), CAST(N'2016-01-10' AS Date), N'', N'', N'', N'', N'')
INSERT [dbo].[RmLabel] ([AutoID], [cSerialNumber], [FitemID], [cInvCode], [cInvName], [cInvStd], [cFullName], [cDefaultLoc], [cDefaultSP], [cLotNo], [cVendor], [iQuantity], [dDate], [cMemo], [cDefine1], [cDefine2], [cDefine3], [cDefine4]) VALUES (3, N'RM1601160001', N'2462', N'11.01.005', N'原料', N'PA66GF 30', N'原材料_塑胶类_原料', N'0', N'0', N'w20160116001', N'上海依多科化工有限公司', CAST(100.0000 AS Decimal(18, 4)), CAST(N'2016-01-16' AS Date), N'', N'', N'', N'', N'')
INSERT [dbo].[RmLabel] ([AutoID], [cSerialNumber], [FitemID], [cInvCode], [cInvName], [cInvStd], [cFullName], [cDefaultLoc], [cDefaultSP], [cLotNo], [cVendor], [iQuantity], [dDate], [cMemo], [cDefine1], [cDefine2], [cDefine3], [cDefine4]) VALUES (4, N'RM1601160002', N'2464', N'11.01.007', N'原料', N'PBT HI19', N'原材料_塑胶类_原料', N'0', N'0', N'2020', N'上海金蝶软件科技有限公司', CAST(2020.0000 AS Decimal(18, 4)), CAST(N'2016-01-16' AS Date), N'', N'20505', N'', N'', N'')
INSERT [dbo].[RmLabel] ([AutoID], [cSerialNumber], [FitemID], [cInvCode], [cInvName], [cInvStd], [cFullName], [cDefaultLoc], [cDefaultSP], [cLotNo], [cVendor], [iQuantity], [dDate], [cMemo], [cDefine1], [cDefine2], [cDefine3], [cDefine4]) VALUES (5, N'RM1602210001', N'2467', N'11.01.010', N'原料', N'HostacomDM2T32', N'原材料_塑胶类_原料', N'0', N'0', N'2015002', N'上海普邦贸易有限公司', CAST(20.0000 AS Decimal(18, 4)), CAST(N'2016-02-21' AS Date), N'', N'', N'', N'', N'')
INSERT [dbo].[RmLabel] ([AutoID], [cSerialNumber], [FitemID], [cInvCode], [cInvName], [cInvStd], [cFullName], [cDefaultLoc], [cDefaultSP], [cLotNo], [cVendor], [iQuantity], [dDate], [cMemo], [cDefine1], [cDefine2], [cDefine3], [cDefine4]) VALUES (6, N'RM1602280001', N'4134', N'13.01.0280', N'W77左后侧窗玻璃', N'dd', N'外购外协件_侧窗玻璃_W77左后侧窗玻璃', N'0', N'0', N'w1512180101', N'福耀集团（上海）汽车玻璃有限公司', CAST(2400.0000 AS Decimal(18, 4)), CAST(N'2016-02-28' AS Date), N'dddd', N'dd', N'2016/2/28', N'', N'')
INSERT [dbo].[RmLabel] ([AutoID], [cSerialNumber], [FitemID], [cInvCode], [cInvName], [cInvStd], [cFullName], [cDefaultLoc], [cDefaultSP], [cLotNo], [cVendor], [iQuantity], [dDate], [cMemo], [cDefine1], [cDefine2], [cDefine3], [cDefine4]) VALUES (7, N'RM1602280002', N'4135', N'13.01.0281', N'W77右后侧窗玻璃', N'22', N'外购外协件_侧窗玻璃_W77右后侧窗玻璃', N'0', N'0', N'w1511190102', N'福耀集团（上海）汽车玻璃有限公司', CAST(1263.0000 AS Decimal(18, 4)), CAST(N'2016-02-28' AS Date), N'123', N'12', N'2016/2/28', N'', N'')
SET IDENTITY_INSERT [dbo].[RmLabel] OFF
SET IDENTITY_INSERT [dbo].[Shift] ON 

INSERT [dbo].[Shift] ([AutoID], [cSerialNumber], [BomID], [cFitemID], [FBatchNo], [cInvCode], [cInvName], [cInvStd], [cFullName], [cOrderNumber], [iQuantity], [dDate], [cMemo], [cDeptName], [dAddTime]) VALUES (1, N'SF1601140001', 3, 1982, NULL, N'10.01.02.02.33D845051', N'GP4后风窗玻璃总成', N'33D 845 051', N'成品_上海大众_Santana Vista_风挡玻璃_GP4后风窗玻璃总成', N'200202', 100, CAST(N'2016-01-14' AS Date), N'          ', N'', CAST(N'2016-01-14 00:23:40.173' AS DateTime))
INSERT [dbo].[Shift] ([AutoID], [cSerialNumber], [BomID], [cFitemID], [FBatchNo], [cInvCode], [cInvName], [cInvStd], [cFullName], [cOrderNumber], [iQuantity], [dDate], [cMemo], [cDeptName], [dAddTime]) VALUES (2, N'SF1601140002', 5, 1993, NULL, N'10.01.02.03.330857961B041', N'烟灰缸', N'330 857 961B 041', N'成品_上海大众_Santana Vista_内饰件_烟灰缸', N'10', 10, CAST(N'2016-01-14' AS Date), N'          ', N'', CAST(N'2016-01-14 00:24:27.443' AS DateTime))
INSERT [dbo].[Shift] ([AutoID], [cSerialNumber], [BomID], [cFitemID], [FBatchNo], [cInvCode], [cInvName], [cInvStd], [cFullName], [cOrderNumber], [iQuantity], [dDate], [cMemo], [cDeptName], [dAddTime]) VALUES (3, N'SF1601140003', 4, 1986, NULL, N'10.01.02.02.33D845091', N'GP4前风窗玻璃总成', N'33D 845 091', N'成品_上海大众_Santana Vista_风挡玻璃_GP4前风窗玻璃总成', N'202010', 20, CAST(N'2016-01-14' AS Date), N'          ', N'', CAST(N'2016-01-14 00:27:13.843' AS DateTime))
INSERT [dbo].[Shift] ([AutoID], [cSerialNumber], [BomID], [cFitemID], [FBatchNo], [cInvCode], [cInvName], [cInvStd], [cFullName], [cOrderNumber], [iQuantity], [dDate], [cMemo], [cDeptName], [dAddTime]) VALUES (4, N'SF1601140004', 3, 1982, NULL, N'10.01.02.02.33D845051', N'GP4后风窗玻璃总成', N'33D 845 051', N'成品_上海大众_Santana Vista_风挡玻璃_GP4后风窗玻璃总成', N'200202', 20, CAST(N'2016-01-14' AS Date), N'          ', N'', CAST(N'2016-01-14 00:34:50.063' AS DateTime))
INSERT [dbo].[Shift] ([AutoID], [cSerialNumber], [BomID], [cFitemID], [FBatchNo], [cInvCode], [cInvName], [cInvStd], [cFullName], [cOrderNumber], [iQuantity], [dDate], [cMemo], [cDeptName], [dAddTime]) VALUES (5, N'SF1601140005', 6, 2010, NULL, N'10.01.02.03.330863243A233', N'副仪表板总成', N'330 863 243A 233', N'成品_上海大众_Santana Vista_内饰件_副仪表板总成', N'1010', 5220, CAST(N'2016-01-14' AS Date), N'          ', N'', CAST(N'2016-01-14 00:36:57.877' AS DateTime))
INSERT [dbo].[Shift] ([AutoID], [cSerialNumber], [BomID], [cFitemID], [FBatchNo], [cInvCode], [cInvName], [cInvStd], [cFullName], [cOrderNumber], [iQuantity], [dDate], [cMemo], [cDeptName], [dAddTime]) VALUES (6, N'SF1601160001', 9, 2774, NULL, N'14.01.04.001', N'Touran左三角窗玻璃', N'1TO 845 411A', N'自制半成品_侧窗玻璃_清洁装箱_Touran左三角窗玻璃', N'2012020', 20, CAST(N'2016-01-14' AS Date), N'          ', N'', CAST(N'2016-01-16 10:25:42.977' AS DateTime))
INSERT [dbo].[Shift] ([AutoID], [cSerialNumber], [BomID], [cFitemID], [FBatchNo], [cInvCode], [cInvName], [cInvStd], [cFullName], [cOrderNumber], [iQuantity], [dDate], [cMemo], [cDeptName], [dAddTime]) VALUES (7, N'SF1602210001', 10, 2776, NULL, N'14.01.04.002', N'Touran右三角窗玻璃', N'1TO 845 412A', N'自制半成品_侧窗玻璃_清洁装箱_Touran右三角窗玻璃', N'200020', 1, CAST(N'2016-01-14' AS Date), N'          ', N'', CAST(N'2016-02-21 14:34:28.080' AS DateTime))
SET IDENTITY_INSERT [dbo].[Shift] OFF
SET IDENTITY_INSERT [dbo].[ShiftDetail] ON 

INSERT [dbo].[ShiftDetail] ([AutoID], [cSerialNumber], [cFitemID], [cInvCode], [cInvName], [cInvStd], [cFullName], [iQuantity], [FBatchNo], [FStockID], [FStockNumber], [FStockName], [FStockPlaceID], [FStockPlaceNumber], [FStockPlaceName], [cMemo], [dAddTime]) VALUES (1, N'SF1601140004', 1981, N'10.01.01.05.330805965C', N'插板', N'330 805 965C', N'成品_上海大众_Santana B2_发动机仓件_插板', CAST(200.0000 AS Decimal(18, 4)), N'WG-150602-29', 4330, N'2.07', N'上海翔踊仓库', 0, N'*', N'*', NULL, NULL)
INSERT [dbo].[ShiftDetail] ([AutoID], [cSerialNumber], [cFitemID], [cInvCode], [cInvName], [cInvStd], [cFullName], [iQuantity], [FBatchNo], [FStockID], [FStockNumber], [FStockName], [FStockPlaceID], [FStockPlaceNumber], [FStockPlaceName], [cMemo], [dAddTime]) VALUES (2, N'SF1601140004', 1981, N'10.01.01.05.330805965C', N'插板', N'330 805 965C', N'成品_上海大众_Santana B2_发动机仓件_插板', CAST(20.0000 AS Decimal(18, 4)), N'WG-150602-29', 4330, N'2.07', N'上海翔踊仓库', 0, N'*', N'*', NULL, NULL)
INSERT [dbo].[ShiftDetail] ([AutoID], [cSerialNumber], [cFitemID], [cInvCode], [cInvName], [cInvStd], [cFullName], [iQuantity], [FBatchNo], [FStockID], [FStockNumber], [FStockName], [FStockPlaceID], [FStockPlaceNumber], [FStockPlaceName], [cMemo], [dAddTime]) VALUES (3, N'SF1601140004', 1981, N'10.01.01.05.330805965C', N'插板', N'330 805 965C', N'成品_上海大众_Santana B2_发动机仓件_插板', CAST(20.0000 AS Decimal(18, 4)), N'WG-150602-29', 4330, N'2.07', N'上海翔踊仓库', 0, N'*', N'*', NULL, NULL)
INSERT [dbo].[ShiftDetail] ([AutoID], [cSerialNumber], [cFitemID], [cInvCode], [cInvName], [cInvStd], [cFullName], [iQuantity], [FBatchNo], [FStockID], [FStockNumber], [FStockName], [FStockPlaceID], [FStockPlaceNumber], [FStockPlaceName], [cMemo], [dAddTime]) VALUES (4, N'SF1601140005', 1992, N'10.01.02.03.330857961A041', N'烟灰缸', N'330 857 961A 041', N'成品_上海大众_Santana Vista_内饰件_烟灰缸', CAST(10101.0000 AS Decimal(18, 4)), N'0', 4095, N'1.12', N'成品库', 277, N'CR', N'CR', NULL, NULL)
INSERT [dbo].[ShiftDetail] ([AutoID], [cSerialNumber], [cFitemID], [cInvCode], [cInvName], [cInvStd], [cFullName], [iQuantity], [FBatchNo], [FStockID], [FStockNumber], [FStockName], [FStockPlaceID], [FStockPlaceNumber], [FStockPlaceName], [cMemo], [dAddTime]) VALUES (5, N'SF1601140005', 1992, N'10.01.02.03.330857961A041', N'烟灰缸', N'330 857 961A 041', N'成品_上海大众_Santana Vista_内饰件_烟灰缸', CAST(1010.0000 AS Decimal(18, 4)), N'WG-150602-33', 4330, N'2.07', N'上海翔踊仓库', 0, N'*', N'*', NULL, NULL)
INSERT [dbo].[ShiftDetail] ([AutoID], [cSerialNumber], [cFitemID], [cInvCode], [cInvName], [cInvStd], [cFullName], [iQuantity], [FBatchNo], [FStockID], [FStockNumber], [FStockName], [FStockPlaceID], [FStockPlaceNumber], [FStockPlaceName], [cMemo], [dAddTime]) VALUES (6, N'SF1601160001', 2468, N'11.01.013', N'原料', N'TPE 121-50M100', N'原材料_塑胶类_原料', CAST(57.0000 AS Decimal(18, 4)), N'y1504250102', 4094, N'1.11', N'原材料库', 1108, N'YP-2-05', N'YP-2-05', NULL, NULL)
INSERT [dbo].[ShiftDetail] ([AutoID], [cSerialNumber], [cFitemID], [cInvCode], [cInvName], [cInvStd], [cFullName], [iQuantity], [FBatchNo], [FStockID], [FStockNumber], [FStockName], [FStockPlaceID], [FStockPlaceNumber], [FStockPlaceName], [cMemo], [dAddTime]) VALUES (7, N'SF1601160001', 2502, N'13.01.0018', N'Touran前侧窗玻璃', N'1T0 845 411A', N'外购外协件_侧窗玻璃_Touran前侧窗玻璃', CAST(400.0000 AS Decimal(18, 4)), N'w14100901', 4094, N'1.11', N'原材料库', 460, N'原料废', N'原料废', NULL, NULL)
INSERT [dbo].[ShiftDetail] ([AutoID], [cSerialNumber], [cFitemID], [cInvCode], [cInvName], [cInvStd], [cFullName], [iQuantity], [FBatchNo], [FStockID], [FStockNumber], [FStockName], [FStockPlaceID], [FStockPlaceNumber], [FStockPlaceName], [cMemo], [dAddTime]) VALUES (8, N'SF1601160001', 2980, N'16.03.002', N'胶水', N'CH487A', N'辅助材料_胶水_胶水', CAST(2.5600 AS Decimal(18, 4)), N'y1504130102', 4094, N'1.11', N'原材料库', 734, N'HB-2-01', N'HB-2-01', NULL, NULL)
INSERT [dbo].[ShiftDetail] ([AutoID], [cSerialNumber], [cFitemID], [cInvCode], [cInvName], [cInvStd], [cFullName], [iQuantity], [FBatchNo], [FStockID], [FStockNumber], [FStockName], [FStockPlaceID], [FStockPlaceNumber], [FStockPlaceName], [cMemo], [dAddTime]) VALUES (9, N'SF1601160001', 2991, N'16.04.001', N'固化剂', N'CH487B', N'辅助材料_固化剂_固化剂', CAST(160.0000 AS Decimal(18, 4)), N'y1504210101', 4094, N'1.11', N'原材料库', 706, N'HA-3-03', N'HA-3-03', NULL, NULL)
INSERT [dbo].[ShiftDetail] ([AutoID], [cSerialNumber], [cFitemID], [cInvCode], [cInvName], [cInvStd], [cFullName], [iQuantity], [FBatchNo], [FStockID], [FStockNumber], [FStockName], [FStockPlaceID], [FStockPlaceNumber], [FStockPlaceName], [cMemo], [dAddTime]) VALUES (10, N'SF1601160001', 2518, N'13.01.0038', N'螺钉总成', N'HXTX1003T02', N'外购外协件_侧窗玻璃_螺钉总成', CAST(400.0000 AS Decimal(18, 4)), N'W1504100101', 4094, N'1.11', N'原材料库', 1141, N'YQ-1-18', N'YQ-1-18', NULL, NULL)
INSERT [dbo].[ShiftDetail] ([AutoID], [cSerialNumber], [cFitemID], [cInvCode], [cInvName], [cInvStd], [cFullName], [iQuantity], [FBatchNo], [FStockID], [FStockNumber], [FStockName], [FStockPlaceID], [FStockPlaceNumber], [FStockPlaceName], [cMemo], [dAddTime]) VALUES (11, N'SF1602210001', 1980, N'10.01.01.05.330805961C', N'进气罩总成', N'330 805 961C', N'成品_上海大众_Santana B2_发动机仓件_进气罩总成', CAST(20.0000 AS Decimal(18, 4)), N'WG-150602-63', 4095, N'1.12', N'成品库', 277, N'CR', N'CR', NULL, NULL)
SET IDENTITY_INSERT [dbo].[ShiftDetail] OFF
SET IDENTITY_INSERT [dbo].[Tb_Collect] ON 

INSERT [dbo].[Tb_Collect] ([id], [eKey], [cName], [tName], [cType]) VALUES (1, N'cSerialNumber', N'序列号', N'RmLabel', N'DataType.String')
INSERT [dbo].[Tb_Collect] ([id], [eKey], [cName], [tName], [cType]) VALUES (3, N'FitemID', N'KisID', N'RmLabel', N'DataType.String')
INSERT [dbo].[Tb_Collect] ([id], [eKey], [cName], [tName], [cType]) VALUES (6, N'cInvCode', N'编码', N'RmLabel', N'DataType.String')
INSERT [dbo].[Tb_Collect] ([id], [eKey], [cName], [tName], [cType]) VALUES (7, N'cInvName', N'名称', N'RmLabel', N'DataType.String')
INSERT [dbo].[Tb_Collect] ([id], [eKey], [cName], [tName], [cType]) VALUES (13, N'cInvStd', N'规格', N'RmLable', N'DataType.String')
INSERT [dbo].[Tb_Collect] ([id], [eKey], [cName], [tName], [cType]) VALUES (15, N'cFullName', N'全称', N'RmLable', N'DataType.String')
INSERT [dbo].[Tb_Collect] ([id], [eKey], [cName], [tName], [cType]) VALUES (16, N'cDefaultLoc', N'默认仓库', N'RmLable', N'DataType.String')
INSERT [dbo].[Tb_Collect] ([id], [eKey], [cName], [tName], [cType]) VALUES (17, N'cDefaultSP', N'默认库位', N'RmLable', N'DataType.String')
INSERT [dbo].[Tb_Collect] ([id], [eKey], [cName], [tName], [cType]) VALUES (18, N'cLotNo', N'批号', N'RmLable', N'DataType.String')
INSERT [dbo].[Tb_Collect] ([id], [eKey], [cName], [tName], [cType]) VALUES (19, N'cVendor', N'供应商', N'RmLable', N'DataType.String')
INSERT [dbo].[Tb_Collect] ([id], [eKey], [cName], [tName], [cType]) VALUES (22, N'iQuantity', N'数量', N'RmLable', N'DataType.String')
INSERT [dbo].[Tb_Collect] ([id], [eKey], [cName], [tName], [cType]) VALUES (23, N'dDate', N'入库日期', N'RmLable', N'DataType.String')
INSERT [dbo].[Tb_Collect] ([id], [eKey], [cName], [tName], [cType]) VALUES (24, N'cMemo', N'备注', N'RmLable', N'DataType.String')
SET IDENTITY_INSERT [dbo].[Tb_Collect] OFF
ALTER TABLE [dbo].[BPrinter] ADD  CONSTRAINT [DF_BPrinter_dAddtime]  DEFAULT (getdate()) FOR [dAddtime]
GO
ALTER TABLE [dbo].[ProCheckScan] ADD  CONSTRAINT [DF_ProCheckScan_dAddTime]  DEFAULT (getdate()) FOR [dAddTime]
GO
ALTER TABLE [dbo].[ProCheckScan] ADD  CONSTRAINT [DF_ProCheckScan_bUpdate]  DEFAULT ((0)) FOR [bUpdate]
GO
ALTER TABLE [dbo].[ProDeliveryDetail] ADD  CONSTRAINT [DF_ProDeliveryDetail_bUpdate]  DEFAULT ((0)) FOR [bUpdate]
GO
ALTER TABLE [dbo].[ProDeliveryScan] ADD  CONSTRAINT [DF_ProDeliveryScan_dAddTime]  DEFAULT (getdate()) FOR [dAddTime]
GO
ALTER TABLE [dbo].[ProDeliveryScan] ADD  CONSTRAINT [DF_ProDeliveryScan_bUpdate]  DEFAULT ((0)) FOR [bUpdate]
GO
ALTER TABLE [dbo].[ProStoreDetail] ADD  CONSTRAINT [DF_ProStoreDetail_bDelivery]  DEFAULT ((0)) FOR [bDelivery]
GO
ALTER TABLE [dbo].[ProStoreDetail] ADD  CONSTRAINT [DF_ProStoreDetail_bUpdate]  DEFAULT ((0)) FOR [bUpdate]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自增ID
   ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BFunction', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'功能表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BFunction'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BRole'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色功能表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BRoleFunction'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[12] 4[7] 2[37] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "BRole"
            Begin Extent = 
               Top = 14
               Left = 354
               Bottom = 153
               Right = 503
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "BUser"
            Begin Extent = 
               Top = 14
               Left = 50
               Bottom = 208
               Right = 215
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_BUserRole'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_BUserRole'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[7] 4[54] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "a"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 145
               Right = 213
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "b"
            Begin Extent = 
               Top = 6
               Left = 251
               Bottom = 145
               Right = 429
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 24
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 3375
         Alias = 1695
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_ProductLabel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_ProductLabel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_RoleAndUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_RoleAndUser'
GO
USE [master]
GO
ALTER DATABASE [JWMSH_2016] SET  READ_WRITE 
GO
