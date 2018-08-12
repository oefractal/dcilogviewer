namespace DciLogViewer.Models
{
  /// <summary>
  /// Список записей лог-файла.
  /// </summary>
  public class LogEntries
  {
    public int records { get; set; }
    public int page { get; set; }
    public int total { get; set; }
    public LogEntry[] rows { get; set; }
  }
}