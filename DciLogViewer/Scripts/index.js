$(function () {
  $("#select-file-button").on("click", function () {
    $("#log-view-grid").jsGrid("loadData");
  });
  $("#log-view-grid").jsGrid({
    height: "100%",
    width: "100%",

    autoload: true,
    paging: true,
    pageLoading: true,
    pageSize: 15,
    pageIndex: 1,

    controller: {
      loadData: function (filter) {
        return $.ajax({
          url: "/Log/GetLogEntries?pageIndex=" + filter.pageIndex +
            "&pageSize=" + filter.pageSize +
            "&fileName=" + encodeURIComponent($("#file-name-input").val()),
          async: false
        });
      }
    },

    fields: [
      { name: "Date", title: "Дата", type: "text", width: 90 },
      { name: "Time", title: "Время", type: "text", width: 90 },
      { name: "ProcessID", title: "ИД процесса", type: "number" },
      { name: "ThreadID", title: "ИД потока", type: "number" },
      { name: "Level", title: "Уровень", type: "text" },
      { name: "Operation", title: "Операция", type: "text" },
      { name: "Message", title: "Сообщение", type: "text" },
      { name: "ProcessName", title: "Имя процесса", type: "text" },
      { name: "ProcessGlobalId", title: "ИД процесса", type: "text" },
      { name: "MessageName", title: "Имя сообщения", type: "text" },
      { name: "MessageGlobalId", title: "ИД сообщения", type: "text" },
      { name: "Sender", title: "Отправитель", type: "text", width: 150 },
      { name: "Receiver", title: "Получатель", type: "text" },
      { name: "UserName", title: "Пользователь", type: "text", width: 150 },
      { name: "ExceptionClass", title: "Исключение", type: "text" },
      { name: "Stack", title: "Стек", type: "text" },
      { name: "Version", title: "Версия", type: "text" },
      { name: "Process", title: "Процесс", type: "text" }
    ]
  });
});