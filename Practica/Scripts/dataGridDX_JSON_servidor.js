$(document).ready(function ($) {
    $(function () {
        $("#dataGrid").dxDataGrid({
            dataSource: new DevExpress.data.DataSource({
                //star load
                load: function () {
                    var d = $.Deferred();
                    return $.getJSON("/Sample/datos").done(function (result) {
                        d.resolve(result);
                        console.log(JSON.stringify(result));
                    }).fail(function (error) {
                        alert(error);
                    });
                },//end load
                /*
                 * insert
                 * update
                 * delete
                 */
                insert: function(values) {
                    return $.post("/Sample/Insert").done(function (result) {
                        alert("done");
                    }).fail(function (error) {
                        alert(error);
                    }).always(function () {
                        alert("always");
                    });
                }
            }),
            columns: [
                {
                    dataField: "UserId",
                    caption: "ID",
                    width: 100
                }, {
                    dataField: "UserName",
                    caption: "Nombre de Usuario"

                }, {
                    dataField: "Company",
                    caption: "Compañia"
                }
            ],
            KeyExpr: "UserId",
            filterRow: {
                visible: true
            },
            pager: {
                visible: true
            },
            //panel de busqueda
            searchPanel: {
                visible: true
            },
            showColumnLines: false,
            showRowLines: true,
            rowAlternationEnabled: true,
            showBorders: true,
            footer: true,
            groupPanel: {
                allowColumnDragging: true,
                emptyPanelText: "Drag a column header here to group by that column",
                visible: "auto"
            },
            selection: {
                mode: "multiple"
            },

            //toolbar
            onToolbarPreparing: function (e) {
                //var dataGrid = e.component;
                e.toolbarOptions.items.unshift({
                    location: "before"
                },
                    {
                        location: "after",
                        widget: "dxButton",
                        options: {

                            icon: "save",
                            onClick: function () {
                                DevExpress.ui.dialog.confirm("Are you sure?", "Confirm changes");
                            }
                        }
                    },
                    {
                        location: "after",
                        widget: "dxButton",
                        options: {
                            type: "danger",
                            icon: "remove",

                            onClick: function () {
                                DevExpress.ui.notify("Refresh button", "success");
                            }
                        }
                    });
            }


        });
    });
});