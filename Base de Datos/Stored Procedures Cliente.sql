

-- Stored Procedures

--Cliente

CREATE PROCEDURE PA_DELETE_CLIENTE
(@ID int)
AS 
 	Delete from CLIENTE
	Where (ID =  @ID)


CREATE PROCEDURE PA_SELECT_CLIENTE_All
 AS 
 	Select ID ,APELLIDO2 ,APELLIDO1 ,NOMBRE ,DIRECCION ,ID_DISTRITO ,ID_PROVINCIA ,ID_CANTON ,CODIGO_POSTAL ,COMENTARIO  
	from CLIENTE

CREATE PROCEDURE PA_SELECT_CLIENTE_ByFilter
(@filtro varchar(50))
As
	Select * 
	from CLIENTE 
	where NOMBRE + APELLIDO1 + APELLIDO2 like @filtro


CREATE PROCEDURE PA_SELECT_CLIENTE_ByID 
(@ID int)
AS 
 	Select ID ,APELLIDO2 ,APELLIDO1 ,NOMBRE ,DIRECCION ,ID_DISTRITO ,ID_PROVINCIA ,ID_CANTON ,CODIGO_POSTAL ,COMENTARIO  
	from CLIENTE
	Where (ID =  @ID)


CREATE PROCEDURE PA_INSERT_CLIENTE
 (@ID int, @APELLIDO2 varchar(50), @APELLIDO1 varchar(50), @NOMBRE varchar(50), @DIRECCION varchar(50), 
 @ID_DISTRITO int,@ID_PROVINCIA int,@ID_CANTON int,@CODIGO_POSTAL varchar(50),@COMENTARIO varchar(50))
AS 
 insert into CLIENTE(ID ,APELLIDO2 ,APELLIDO1 ,NOMBRE ,DIRECCION ,ID_DISTRITO ,ID_PROVINCIA ,ID_CANTON ,CODIGO_POSTAL ,COMENTARIO ) 
 values(@ID ,@APELLIDO2 ,@APELLIDO1 ,@NOMBRE ,@DIRECCION ,@ID_DISTRITO ,@ID_PROVINCIA ,@ID_CANTON ,@CODIGO_POSTAL ,
 @COMENTARIO  ) 


CREATE PROCEDURE PA_UPDATE_CLIENTE
 (@ID int, @APELLIDO2 varchar(50), @APELLIDO1 varchar(50), @NOMBRE varchar(50), @DIRECCION varchar(50), 
 @ID_DISTRITO int, @ID_PROVINCIA int, @ID_CANTON int, @CODIGO_POSTAL varchar(50) ,@COMENTARIO varchar(50))
AS 
 	Update  CLIENTE
	Set 	APELLIDO2 =  @APELLIDO2  ,
	APELLIDO1 =  @APELLIDO1  ,
	NOMBRE =  @NOMBRE  ,
	DIRECCION =  @DIRECCION  ,
	ID_DISTRITO =  @ID_DISTRITO  ,
	ID_PROVINCIA =  @ID_PROVINCIA  ,
	ID_CANTON =  @ID_CANTON  ,
	CODIGO_POSTAL =  @CODIGO_POSTAL  ,
	COMENTARIO =  @COMENTARIO  
	Where (ID =  @ID)  


