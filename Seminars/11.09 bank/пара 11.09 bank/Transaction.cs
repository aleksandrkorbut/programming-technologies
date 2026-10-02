using System.Data;

namespace пара_11._09_bank;
// record - Состояние объектов этого класса нельхя изменить
internal record Transaction(decimal Amount, DateTime Date, string Note); // var1

//internal record Transaction (альтернатива var1 )
//{
//    public decimal Amount { get; }
//    public DateTime Data { get; }
//    public string Note { get; }
//    public Transaction(decimal Amount, DateTime Date, string Note)
//    {
//        this.Amount = Amount;
//        this.Note = Note;
//        this.Date = Date;
//    }
//}
