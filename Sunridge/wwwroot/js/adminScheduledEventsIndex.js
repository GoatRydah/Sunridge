﻿var dataTable;

$(document).ready(function () {
    LoadList();
});

function LoadList() {
    dataTable = $('#DT_Load').DataTable({
        "ajax": {
            "url": "/api/adminScheduledEventsIndex/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "subject", "width": "15%" },
            { "data": "description", "width": "15%" },
            { "data": "start", "width": "15%" },
            { "data": "end", "width": "15%" },
            { "data": "isFullDay", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return ` <div class="text-center">
                                <a href="/admin/events/create?id=${data}" class="btn btn-success text-white" style="cursor:pointer; width:100px;">
                                    <i class="far fa-edit"></i> Edit
                                </a>
                                <a class="btn btn-danger text-white" style="cursor:pointer; width:100px;" onClick=Delete('/api/adminScheduledEventsIndex/'+${data})>
                                    <i class="far fa-trash-alt"></i> Delete
                                </a>
                             </div>`;
                }, "width": "25%"
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
        title: "Are you sure you want to delete?",
        text: "You will not be able to restore the data!",
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
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}