namespace DciLogViewer.Models
{
  /// <summary>
  /// Запись лог-файла.
  /// </summary>
  public class LogEntry
  {
    public string Date { get; set; }
    public string Time { get; set; }
    public string ProcessID { get; set; }
    public string ThreadID { get; set; }
    public string Level { get; set; }
    public string Operation { get; set; }
    public string Message { get; set; }
    public string ProcessName { get; set; }
    public string ProcessGlobalId { get; set; }
    public string MessageName { get; set; }
    public string MessageGlobalId { get; set; }
    public string Sender { get; set; }
    public string Receiver { get; set; }
    public string UserName { get; set; }
    public string ExceptionClass { get; set; }
    public string Stack { get; set; }
    public string Version { get; set; }
    public string Process { get; set; }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="line">Исходная строка лог-файла.</param>
    public LogEntry(string line)
    {
      var parts = line.Split('\t');
      var index = 0;
      this.Date = parts[index++];
      this.Time = parts[index++];
      this.ProcessID = parts[index++];
      this.ThreadID = parts[index++];
      this.Level = parts[index++];
      this.Operation = parts[index++];
      this.Message = parts[index++];
      this.ProcessName = parts[index++];
      this.ProcessGlobalId = parts[index++];
      this.MessageName = parts[index++];
      this.MessageGlobalId = parts[index++];
      this.Sender = parts[index++];
      this.Receiver = parts[index++];
      this.UserName = parts[index++];
      this.ExceptionClass = parts[index++];
      this.Stack = parts[index++];
      this.Version = parts[index++];
      this.Process = parts[index++];
  }
}
}