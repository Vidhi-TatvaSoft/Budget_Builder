using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Budget_Builder.Models;

using System.Data;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Budget_Builder.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult GenerateBudgetSheet(string monthList)
    {
        DataViewModel dataViewModel = new DataViewModel();
        dataViewModel.MonthList = JsonConvert.DeserializeObject<List<string>>(monthList);
        dataViewModel.IncomeCategoryList = new List<CategoryViewModel>();
        dataViewModel.ExpenseCategoryList = new List<CategoryViewModel>();
        dataViewModel.TotalIncome = new List<decimal>();
        dataViewModel.TotalExpense = new List<decimal>();
        dataViewModel.ProfitLoss = new List<decimal>();
        dataViewModel.OpeningBalance = new List<decimal>();
        dataViewModel.ClosingBalance = new List<decimal>();

        dataViewModel.IncomeCategoryList.Add(new CategoryViewModel
        {
            CatgeoryName = "",
            Amount = new List<decimal>()
        });
        dataViewModel.ExpenseCategoryList.Add(new CategoryViewModel
        {
            CatgeoryName = "",
            Amount = new List<decimal>()
        });

        for (int i = 0; i < dataViewModel.MonthList.Count; i++)
        {
            dataViewModel.IncomeCategoryList[0].Amount.Add(0);
            dataViewModel.ExpenseCategoryList[0].Amount.Add(0);
            dataViewModel.TotalIncome.Add(0);
            dataViewModel.TotalExpense.Add(0);
            dataViewModel.ProfitLoss.Add(0);
            dataViewModel.OpeningBalance.Add(0);
            dataViewModel.ClosingBalance.Add(0);
        }



        return PartialView("_DataSheetPartial", dataViewModel);
    }

    // public IActionResult UpdateBudgetSheet(string data)
    // {
    //     DataViewModel datavm = JsonConvert.DeserializeObject<DataViewModel>(data);
    //     for (int i = 0; i < datavm.MonthList.Count; i++)
    //     {
    //         datavm.TotalIncome[i] = 0;
    //         datavm.TotalExpense[i] = 0;
    //         datavm.ProfitLoss[i] = 0;
    //         datavm.OpeningBalance[i] = 0;
    //         datavm.ClosingBalance[i] = 0;
    //     }
    //     for (int i = 0; i < datavm.IncomeCategoryList.Count; i++)
    //     {
    //         for (int j = 0; j < datavm.MonthList.Count; j++)
    //         {

    //             datavm.TotalIncome[j]  += datavm.IncomeCategoryList[i].Amount[j];
    //             datavm.TotalExpense[j] += datavm.ExpenseCategoryList[i].Amount[j];
    //             datavm.ProfitLoss[j] = datavm.TotalIncome[j] - datavm.TotalExpense[j];

    //         }
    //     }
    //     for (int i = 0; i < datavm.MonthList.Count; i++)
    //     {
    //         if (i == 0)
    //         {
    //             datavm.OpeningBalance[i] = 0;
    //         }
    //         else
    //         {
    //             datavm.OpeningBalance[i] = datavm.ClosingBalance[i - 1];
    //         }
    //         datavm.ClosingBalance[i] = datavm.OpeningBalance[i] + datavm.ProfitLoss[i];
    //     }

    //     // DataViewModel dataViewModel = new DataViewModel();
    //     // dataViewModel.MonthList = JsonConvert.DeserializeObject<List<string>>(monthList);
    //     // dataViewModel.IncomeCategoryList = JsonConvert.DeserializeObject<List<CategoryViewModel>>(incomeCategoryList);
    //     // dataViewModel.ExpenseCategoryList = JsonConvert.DeserializeObject<List<CategoryViewModel>>(expenseCategoryList);

    //     return PartialView("_DataSheetPartial", datavm);
    // }


    public IActionResult DeleteCategory(string index, bool isIncome, string DatasheetVM)
    {
        DataViewModel? dataViewModel = JsonConvert.DeserializeObject<DataViewModel>(DatasheetVM);
        int idx = Convert.ToInt32(index);
        if (isIncome)
        {
            dataViewModel.IncomeCategoryList.RemoveAt(idx);
            if (dataViewModel.IncomeCategoryList.Count == 0)
            {
                dataViewModel.IncomeCategoryList.Add(new CategoryViewModel
                {
                    CatgeoryName = "",
                    Amount = new List<decimal>()
                });
                for (int i = 0; i < dataViewModel.MonthList.Count; i++)
                {
                    dataViewModel.IncomeCategoryList[0].Amount.Add(0);
                }
            }
        }
        else
        {
            dataViewModel.ExpenseCategoryList.RemoveAt(idx);
            if (dataViewModel.ExpenseCategoryList.Count == 0)
            {
                dataViewModel.ExpenseCategoryList.Add(new CategoryViewModel
                {
                    CatgeoryName = "",
                    Amount = new List<decimal>()
                });
                for (int i = 0; i < dataViewModel.MonthList.Count; i++)
                {
                    dataViewModel.ExpenseCategoryList[0].Amount.Add(0);
                }
            }
        }
        return PartialView("_DataSheetPartial", dataViewModel);
        // return Json(dataViewModel);
    }


    public IActionResult AddCategory(bool isIncome, string DatasheetVM)
    {
        DataViewModel? dataViewModel = JsonConvert.DeserializeObject<DataViewModel>(DatasheetVM);
        if (isIncome)
        {
            dataViewModel.IncomeCategoryList.Add(new CategoryViewModel
            {
                CatgeoryName = "",
                Amount = new List<decimal>()
            });
            for (int i = 0; i < dataViewModel.MonthList.Count; i++)
            {
                dataViewModel.IncomeCategoryList[dataViewModel.IncomeCategoryList.Count - 1].Amount.Add(0);
            }
        }
        else
        {
            dataViewModel.ExpenseCategoryList.Add(new CategoryViewModel
            {
                CatgeoryName = "",
                Amount = new List<decimal>()
            });
            for (int i = 0; i < dataViewModel.MonthList.Count; i++)
            {
                dataViewModel.ExpenseCategoryList[dataViewModel.ExpenseCategoryList.Count - 1].Amount.Add(0);
            }
        }
        return PartialView("_DataSheetPartial", dataViewModel);
    }
}
