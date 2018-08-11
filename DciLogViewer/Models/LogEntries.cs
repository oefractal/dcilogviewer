namespace DciLogViewer.Models
{
  /// <summary>
  /// Список записей лог-файла.
  /// </summary>
  public class LogEntries
  {
    public LogEntry[] data { get; set; }
    public int itemsCount { get; set; }
  }
}