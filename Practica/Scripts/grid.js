$(document).ready(function ($) {
    $(function () {
        $("#dataGrid").dxDataGrid({
            dataSource: new DevExpress.data.DataSource({
                load: function () {
                    var d = $.Deferred();
                    return $.getJSON("/Sample/datos").done(function (data) {
                        d.resolve(JSON.stringify(data));
                        console.log(JSON.stringify(data));

                        alert(JSON.stringify(data));

                    });
                }
            }),


            //toolbar
            onToolbarPreparing: function (e) {
                var dataGrid = e.component;

                e.toolbarOptions.items.unshift({
                    location: "after"
                },
                    {
                        location: "after",
                        widget: "dxButton",
                        options: {
                            icon: "save",
                            onClick: function () {
                                alert("Hola, Geovanny Bienvenido");
                            }
                        }
                    },
                    {
                        location: "after",
                        widget: "dxButton",
                        options: {
                            icon: "remove",
                            onClick: function () {
                                alert("Click en eliminar");
                            }
                        }
                    });

            },


            // keyExpr: "ID",
            columns: ['UserId', 'UserName', 'Company'],
            //edicion
            editing: {
                allowAdding: true,
                allowDeleting: true,
                allowUpdating: true,
                form: null,
                mode: "form",
                popup: null,
                texts: {
                    addRow: "Add a row",
                    cancelAllChanges: "Discard changes",
                    cancelRowChanges: "Cancel",
                    confirmDeleteMessage: "Are you sure you want to delete this record?",
                    confirmDeleteTitle: "",
                    deleteRow: "Delete",
                    editRow: "Edit",
                    saveAllChanges: "Save changes",
                    saveRowChanges: "Save",
                    undeleteRow: "Undelete",
                    validationCancelChanges: "Cancel changes"

                },
                useIcons: true


            },
            //filtro
            filterRow: {
                visible: true
            },
            loadPanel: {
                enabled: null,
                height: 90,
                indicatorSrc: "",
                showIndicator: true,
                showPanel: true,
                text: "Loading...",
                width: 200
            },
            //paginado
            pager: {
                showInfo: true,
                showNavigationButtons: true,
                showPageSizeSelector: true,
                visible: true

            },
            //panel de busqueda
            searchPanel: {
                visible: true
            },
            showBorders: true,
            showRowLines: true
        }).dxDataGrid("instance");
    });
});