

-- Stored Procedures Reportes

ALTER PROCEDURE PA_REPORTE_FACTURA_PRODUCTOS
(@ID int)
AS
	SELECT ORDEN_COMPRA.ID, CLIENTE.ID, (CLIENTE.NOMBRE + ' ' + CLIENTE.APELLIDO1 + ' ' + CLIENTE.APELLIDO2) as Nombre,
	GETDATE(), DETALLE.ID_DETALLE, DETALLE.ID_PRODUCTO, PRODUCTO.DESCRIPCION, DETALLE.CANTIDAD,
	PRODUCTO.DESCUENTO ,DETALLE.TOTAL_DETALLE, ORDEN_COMPRA.SUBTOTAL, ORDEN_COMPRA.TOTAL
	FROM CLIENTE, PRODUCTO, ORDEN_COMPRA, DETALLE
	where ORDEN_COMPRA.ID_CLIENTE = CLIENTE.ID and DETALLE.ID_ORDEN = ORDEN_COMPRA.ID and 
	DETALLE.ID_PRODUCTO = PRODUCTO.ID and ORDEN_COMPRA.ID = @ID


exec PA_REPORTE_FACTURA_PRODUCTOS @ID = 56

Select * from ORDEN_COMPRA

drop procedure PA_REPORTE_FACTURA_PRODUCTOS


CREATE PROCEDURE PA_REPORTE_FACTURA_VIDEOJUEGO
(@ID int)
AS
	SELECT ORDEN_COMPRA_VIDEOJUEGO.ID, CLIENTE.ID, (CLIENTE.NOMBRE + ' ' + CLIENTE.APELLIDO1 + ' ' + CLIENTE.APELLIDO2) as Nombre,
	GETDATE(), DETALLE_VIDEOJUEGO.ID_DETALLE, DETALLE_VIDEOJUEGO.ID_PRODUCTO, VIDEOJUEGO.NOMBRE, DETALLE_VIDEOJUEGO.CANTIDAD,
	VIDEOJUEGO.DESCUENTO, DETALLE_VIDEOJUEGO.TOTAL, ORDEN_COMPRA_VIDEOJUEGO.SUBTOTAL, ORDEN_COMPRA_VIDEOJUEGO.TOTAL
	FROM CLIENTE, VIDEOJUEGO, ORDEN_COMPRA_VIDEOJUEGO, DETALLE_VIDEOJUEGO
	where ORDEN_COMPRA_VIDEOJUEGO.ID_CLIENTE = CLIENTE.ID and DETALLE_VIDEOJUEGO.ID_ORDEN = ORDEN_COMPRA_VIDEOJUEGO.ID
	and DETALLE_VIDEOJUEGO.ID_PRODUCTO = VIDEOJUEGO.ID and ORDEN_COMPRA_VIDEOJUEGO.ID = @ID


ALTER PROCEDURE PA_REPORTE_PRODUCTO
(@ID int)
AS
	SELECT *
	FROM PRODUCTO
	where PRODUCTO.ID = @ID and PRODUCTO.ESTADO = 1


ALTER PROCEDURE PA_REPORTE_PRODUCTO_ALL
AS
	SELECT *
	FROM PRODUCTO
	where PRODUCTO.ESTADO = 1


CREATE PROCEDURE PA_REPORTE_VIDEOJUEGO
(@ID int)
AS
	SELECT *
	FROM VIDEOJUEGO
	where VIDEOJUEGO.ID = @ID and VIDEOJUEGO.ESTADO = 1


CREATE PROCEDURE PA_REPORTE_VIDEOJUEGO_ALL
AS
	SELECT *
	FROM VIDEOJUEGO
	where VIDEOJUEGO.ESTADO = 1


CREATE PROCEDURE PA_REPORTE_ORDEN_COMPRA_POR_FECHA
(@FECHA date)
AS
	Select *
	from ORDEN_COMPRA
	where ORDEN_COMPRA.FECHA_ORDEN = @FECHA



CREATE PROCEDURE PA_REPORTE_ORDEN_COMPRA_VIDEOJUEGO_POR_FECHA
(@FECHA date)
AS
	Select *
	from ORDEN_COMPRA_VIDEOJUEGO
	where ORDEN_COMPRA_VIDEOJUEGO.FECHA_ORDEN = @FECHA


CREATE PROCEDURE PA_REPORTE_CANTIDAD_PRODUCTOS_VENDIDOS
(@FECHA_INICIO date, @FECHA_FINAL date)
AS
	Select SUM(DETALLE.CANTIDAD) as CantidadVendida, PRODUCTO.DESCRIPCION
	from DETALLE, PRODUCTO, ORDEN_COMPRA
	where DETALLE.ID_PRODUCTO = PRODUCTO.ID and ORDEN_COMPRA.ID = DETALLE.ID_ORDEN and 
	ORDEN_COMPRA.FECHA_ORDEN >= @FECHA_INICIO and ORDEN_COMPRA.FECHA_ORDEN <= @FECHA_FINAL
	group by PRODUCTO.DESCRIPCION 


CREATE PROCEDURE PA_REPORTE_CANTIDAD_VIDEOJUEGOS_VENDIDOS
(@FECHA_INICIO date, @FECHA_FINAL date)
AS
	Select SUM(DETALLE_VIDEOJUEGO.CANTIDAD) as CantidadVendida, VIDEOJUEGO.NOMBRE
	from DETALLE_VIDEOJUEGO, VIDEOJUEGO, ORDEN_COMPRA_VIDEOJUEGO
	where DETALLE_VIDEOJUEGO.ID_PRODUCTO = VIDEOJUEGO.ID and ORDEN_COMPRA_VIDEOJUEGO.ID = DETALLE_VIDEOJUEGO.ID_ORDEN and 
	ORDEN_COMPRA_VIDEOJUEGO.FECHA_ORDEN >= @FECHA_INICIO and ORDEN_COMPRA_VIDEOJUEGO.FECHA_ORDEN <= @FECHA_FINAL
	group by VIDEOJUEGO.NOMBRE 
