using DciLogViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.IO;
using System.Web.Mvc;
using System.Text;

namespace DciLogViewer.Controllers
{
  /// <summary>
  /// Контроллер лог-файлов.
  /// </summary>
  public class LogController : Controller
  {
    /// <summary>
    /// Получить главную страницу.
    /// </summary>
    /// <returns></returns>
    public ActionResult Index()
    {
      return View();
    }

    /// <summary>
    /// Получить страницу "О программе".
    /// </summary>
    /// <returns></returns>
    public ActionResult About()
    {
      ViewBag.Message = "Your application description page.";

      return View();
    }

    /// <summary>
    /// Получить строки лог-файла.
    /// </summary>
    /// <param name="fileName">Имя файла.</param>
    /// <returns></returns>
    public ActionResult GetLogEntries(string fileName)
    {
      int pageIndex = int.Parse(this.Request.Params.Get("page"));
      int pageSize = int.Parse(this.Request.Params.Get("rows"));

      if (!System.IO.File.Exists(fileName))
          return new HttpNotFoundResult();

      var totalLineCount = 0;
      var logEntryList = new List<LogEntry>();
      using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
      {
        using (var streamReader = new StreamReader(fileStream, Encoding.GetEncoding(1251)))
        {
          var skipLineCount = (pageIndex - 1) * pageSize;
          while (skipLineCount > 0)
          {
            streamReader.ReadLine();
            skipLineCount--;
            totalLineCount++;
          }
          var currentLine = streamReader.ReadLine();
          var pageLineCount = pageSize;
          while (pageLineCount > 0 && currentLine != null)
          {
            var logEntry = new LogEntry(currentLine);
            logEntryList.Add(logEntry);
            pageLineCount--;
            totalLineCount++;
            currentLine = streamReader.ReadLine();
          }
          while (currentLine != null)
          {
            totalLineCount++;
            currentLine = streamReader.ReadLine();
          }
        }
      }
      var logEntries = new LogEntries();
      logEntries.rows = new LogEntry[logEntryList.Count];
      int index = 0;
      foreach (var logEntry in logEntryList)
        logEntries.rows[index++] = logEntry;
      logEntries.page = pageIndex;
      logEntries.records = totalLineCount;
      logEntries.total = (int)Math.Ceiling((double)totalLineCount / pageSize);
      return this.Json(logEntries, JsonRequestBehavior.AllowGet);
    }
  }
}