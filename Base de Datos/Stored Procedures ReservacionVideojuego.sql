

-- Stored Procedures ReservacionVideojuego


CREATE PROCEDURE PA_DELETE_RESERVACION_VIDEOJUEGO_ByID 
(@ID int)
AS 
 	Delete from RESERVACION_VIDEOJUEGO
	Where (ID =  @ID)


CREATE PROCEDURE PA_SELECT_RESERVACION_VIDEOJUEGO_All
 AS 
 	Select ID ,ID_CLIENTE ,ID_PRODUCTO ,ADELANTO  from RESERVACION_VIDEOJUEGO


CREATE PROCEDURE PA_SELECT_RESERVACION_VIDEOJUEGO_ByID 
(@ID int)
AS 
 	Select ID ,ID_CLIENTE ,ID_PRODUCTO ,ADELANTO  from RESERVACION_VIDEOJUEGO
	Where (ID =  @ID)


CREATE PROCEDURE PA_SELECT_RESERVACION_VIDEOJUEGO_ByIdCliente
(@ID_CLIENTE int)
AS 
 	Select ID ,ID_CLIENTE ,ID_PRODUCTO ,ADELANTO  from RESERVACION_VIDEOJUEGO
	Where (ID_CLIENTE =  @ID_CLIENTE)


CREATE PROCEDURE PA_INSERT_RESERVACION_VIDEOJUEGO
 (@ID int,@ID_CLIENTE int,@ID_PRODUCTO int,@ADELANTO money)
AS 
 insert into RESERVACION_VIDEOJUEGO(ID ,ID_CLIENTE ,ID_PRODUCTO ,ADELANTO ) 
 values(@ID ,@ID_CLIENTE ,@ID_PRODUCTO ,@ADELANTO  )


 CREATE PROCEDURE PA_UPDATE_RESERVACION_VIDEOJUEGO
 (@ID int,@ID_CLIENTE int,@ID_PRODUCTO int,@ADELANTO money)
AS 
 	Update  RESERVACION_VIDEOJUEGO
	Set 	ID_CLIENTE =  @ID_CLIENTE  ,
	ID_PRODUCTO =  @ID_PRODUCTO  ,
	ADELANTO =  @ADELANTO  
	Where (ID =  @ID)  