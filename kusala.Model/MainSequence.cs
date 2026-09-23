using kusala.Contracts;

namespace kusala.Model;

public class MainSequence
{
    private readonly IWallDataGraber _wallDataGraber;

    public MainSequence(IWallDataGraber wallDataGraber)
    {
        _wallDataGraber = wallDataGraber;
    }

    public void Go()
    {
        //в этом методе будет основная логика плагина

        //например можно написать следующую последовательность
        //1. Получаем данные о кладочных и несущих стенах
        var wallData = _wallDataGraber.Grab();
        //2. Определяем, между какими элементами надо поставить размер
        //3. Определяем цепочки размеров (когда они тдут вдоль одной линии)
        //4. Линии размеров
        //5. Накопленные данные передаём в процессор расстановки размеров, который работает с ревит API
    }
}
