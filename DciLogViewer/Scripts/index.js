function resizeGrid() {
  var gridParentWidth = $("#log-view-grid-container").width();
  var gridParentHeight = $("#log-view-grid-container").height();
  $("#log-view-grid").jqGrid("setGridWidth", gridParentWidth);
  $("#log-view-grid").jqGrid("setGridHeight", gridParentHeight - $("#log-view-grid-pager").height() - $("#file-name-input-and-label").height() - 50);
}

$(function () {
  $("#select-file-button").on("click", function () {
    $("#log-view-grid").trigger('reloadGrid');
  });

  $("#log-view-grid").jqGrid({
    url: '/Log/GetLogEntries',
    postData: {
      fileName: function () { return $("#file-name-input").val();}
    },
    mtype: "GET",
    datatype: "json",
    colModel: [
      { label: "Дата", name: "Date", width: 75 },
      { label: "Время", name: "Time", width: 150 },
      { label: "ИД процесса", name: "ProcessID", width: 150 },
      { label: "ИД потока", name: "ThreadID", width: 150 },
      { label: "Уровень", name: "Level", width: 150 },
      { label: "Операция", name: "Operation", width: 150 },
      { label: "Сообщение", name: "Message", width: 150 },
      { label: "Имя процесса", name: "ProcessName", width: 150 },
      { label: "ИД процесса", name: "ProcessGlobalId", width: 150 },
      { label: "Имя сообщения", name: "MessageName", width: 150 },
      { label: "ИД сообщения", name: "MessageGlobalId", width: 150 },
      { label: "Отправитель", name: "Sender", width: 150 },
      { label: "Получатель", name: "Receiver", width: 150 },
      { label: "Пользователь", name: "UserName", width: 150 },
      { label: "Исключение", name: "ExceptionClass", width: 150 },
      { label: "Стек", name: "Stack", width: 150 },
      { label: "Версия", name: "Version", width: 150 },
      { label: "Процесс", name: "Process", width: 150 }
    ],
    page: 1,
    rowNum: 20,
    scrollPopUp: true,
    scrollLeftOffset: "83%",
    viewrecords: true,
    scroll: 1, 
    emptyrecords: 'Прокрутите для загрузки следующей страницы', 
    pager: "#log-view-grid-pager"
  });
  resizeGrid();

  $(window).resize(function () {
    resizeGrid();
  });
});