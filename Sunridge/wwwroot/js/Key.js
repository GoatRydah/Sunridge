﻿var dataTable;

//do not call this funtion until the page is fully loaded
$(document).ready(function () {
    loadList();
});

//this is for the Category loading
function loadList() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/keys/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "serialNumber", "width": "35%" },
            { "data": "year", "width": "35%" },

            {
                "data": "keyId",
                "render": function (data) {
                    return ` <div class="text-center">
                                <a href="/Admin/Keys/upsert?id=${data}" class="btn btn-success text-white" style="cursor:pointer; width:100px;">
                                    <i class="far fa-edit"></i> Edit
                                </a>
                                <a class="btn btn-danger text-white" style="cursor:pointer; width:100px;" onclick=Delete('/api/keys/'+${data})>
                                    <i class="far fa-trash-alt"></i> Delete
                                </a>
                    </div>`;
                }, "width": "30%"
            }
        ],
        "language": {
            "emptyTable": "no data found."
        },
        "width": "100%"
    });
}


function Delete(url) {
    swal({
        title: "Are you sure you want to Delete?",
        text: "You will not be able to restore data!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: 'DELETE',
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}