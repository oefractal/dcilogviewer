function resizeGrid() {
  var gridParentWidth = $("#log-view-grid-container").width();
  var gridParentHeight = $("#log-view-grid-container").height();
  $("#log-view-grid").jqGrid("setGridWidth", gridParentWidth);
  $("#log-view-grid").jqGrid("setGridHeight", gridParentHeight - $("#log-view-grid-pager").height() - $("#file-name-input-and-label").height() + 8);
}

function handleRowSelected() {
  var grid = $("#log-view-grid");
  var selRowId = grid.jqGrid("getGridParam", "selrow");
  var cellValue = grid.jqGrid("getCell", selRowId, "Stack");
  cellValue = cellValue.replace(/\sat\s/g, "\n at ");
  $("#stack-input").val(cellValue);
}

$(function () {
  $("#select-file-button").button();
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
      { label: "Сообщение", name: "Message", width: 220 },
      { label: "Имя процесса", name: "ProcessName", width: 300 },
      { label: "ИД процесса", name: "ProcessGlobalId", width: 385 },
      { label: "Имя сообщения", name: "MessageName", width: 220 },
      { label: "ИД сообщения", name: "MessageGlobalId", width: 385 },
      { label: "Отправитель", name: "Sender", width: 150 },
      { label: "Получатель", name: "Receiver", width: 150 },
      { label: "Пользователь", name: "UserName", width: 150 },
      { label: "Исключение", name: "ExceptionClass", width: 150 },
      { label: "Стек", name: "Stack", width: 150 },
      { label: "Версия", name: "Version", width: 150 },
      { label: "Процесс", name: "Process", width: 150 }
    ],
    rowNum: 28,
    viewrecords: true,
    onSelectRow: handleRowSelected, 
    autowidth: true,
    shrinkToFit: false,
    pager: "#log-view-grid-pager"
  });
  resizeGrid();

  $(window).resize(function () {
    resizeGrid();
  });
});