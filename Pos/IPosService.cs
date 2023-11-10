using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos
{
  public interface IPosService
  {
    public void GetData();
    public bool DataValidation();
    public string DataChecker();
    public void AddTransaction();
    public void ShowTransactionList(string select);
    public void SeparateTransaction();
    public void TransactionSetter(List<string> list, string type);
  }
}