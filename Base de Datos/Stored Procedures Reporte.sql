

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