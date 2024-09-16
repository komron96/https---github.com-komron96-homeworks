Vehicle Komas = new Vehicle();
Komas.AddDetail("Колёса");
Komas.AddDetail("Руль");
Komas.AddDetail("Окна");
Komas.AddDetail("Двери");   

Komas["Двери"] = new DetailPart {DetailName = "Копот"};


public sealed class Vehicle
{
    private readonly List<DetailPart> _detailsList;
    public string Name { get; set; }
    public string Company { get; set; }
    public string Color { get; set; }
    public string MaxSpeed { get; set; }

    //Методы удаления, добавления и получения деталей
    public void AddDetail(string name)
    {
        _detailsList.Add(new DetailPart() { DetailName = name });
    }
    public DetailPart GetDetail(string name)
    {
        return _detailsList.Find(item => item.DetailName == name);
    }
    public void Delete(string name)
    {
        var detail = _detailsList.FirstOrDefault(item => item.DetailName == name);
        if (detail is not null)
        {
            _detailsList.Remove(detail);
        }
    }
    public bool ChangeDescription(string name, string newDesctription)
    {
        DetailPart DetailWithNewDesc = _detailsList.Find(item => item.DetailName == name);
        if (DetailWithNewDesc is null) return false;
        DetailWithNewDesc.Description = newDesctription;
        return true;
    }

    //Индексатор - используются чтоб проиндексировать какой либо массив и изменить их свойства при необходимости
    public DetailPart this[string name]   //У индексатора нет названия и используем this 
    //Данные индекстор в классе позволяет изменить Имя уже существующей детали
    {
        get => _detailsList.Find(item => item.DetailName == name);
        set { DetailPart detailpart = _detailsList.Find(item => item.DetailName == name); detailpart.DetailName = value.DetailName; }
    }
    public IEnumerator<DetailPart> GetEnumerator()
    {
        foreach(DetailPart detailPart in _detailsList)
            yield return detailPart;
            
    }
    
}
public sealed class DetailPart
{
    public string DetailName { get; set; }
    public string Weight { get; set; }
    public string Description { get; set; }
}