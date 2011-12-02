namespace BLL
{
    public enum EstatusTransaccion
    {
        Completa = 1,
        Cancelada = 2,
        Pendiente = 3,
    }

    public enum EstatusCheque
    {
        Pendiente = 1,
        Cancelado = 2,
        Valido = 3,
    }

    public enum TipoTransaccion
    {
        VentaDll = 1,
        CompraDll = 2,
        CambioCheque = 3,
        SalidaPrestamo = 4,
        EntradaPrestamo = 5,
        RetiroInventario =6,
        DepositoInventario = 7,
        Corte= 8,
        Gasto = 9,
    }

    public enum EstatusPrestamo
    {
        Creado = 1,
        Curso = 2,
        Pagado = 3,
        Vencido = 4,
        Cancelado = 5,
        Terminado =6,
    }

    public enum TipoMovimiento
    {
        EntregaPrestamo = 1,
        Corte = 2,
        Pago = 3,
        PagoCapital = 4,
        Descuento = 5,
        Ajuste = 6,
    }

    public enum Reporte
    {
        CorteCaja,
    }
}