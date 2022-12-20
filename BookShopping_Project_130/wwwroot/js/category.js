﻿var dataTable;
$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Category/GetAll"
        },
        "columns": [
            { "data": "name", "width": "70%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                           <div class="text-center">
                            <a class="btn btn-primary" href="/Admin/Category/Upsert/${data}">
                                <i class="fas fa-edit"></i>
                            </a>
                            <a class="btn btn-danger" onClick=Delete("/Admin/Category/Delete/${data}")>
                                 <i class="fas fa-trash-alt"></i>
                            </a>
                           </div>
                            `;
                }
            }
           ]
    })
}
function Delete(url) {
    swal({
        title: "Want to delete data ?",
        icon: "warning",
        text: "Delete Inforamtion !!!",
        buttons: true,
        dangerModel: true
    }).then((willdelete) => {
        if (willdelete) {
            $.ajax({
                url: url,
                type: "DELETE",
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                        //dataTable.ajax.api.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}