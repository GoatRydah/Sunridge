var dataTable;

$(document).ready(function () {
    LoadList();
});

function LoadList() {
    dataTable = $('#DT_Load').DataTable({
        "ajax": {
            "url": "/api/HoaLots/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "lotNumber", "width": "15%" },
            { "data": "streetAddress", "width": "15%" },
            { "data": "userName", "width": "15%" },
            { "data": "taxId", "width": "15%" },
            { "data": "lotInventory", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return ` <div class="text-center">
                                <a href="/admin/hOALots/upsert?id=${data}" class="btn btn-info text-white" style="cursor:pointer; width:100px;">
                                    <i class="far fa-edit"></i> Edit
                                </a>
                                <a href="/admin/hOALots/filesIndex?id=${data}" class="btn btn-dark text-white" style="cursor:pointer; width:100px;">
                                    <i class="far fa-file-alt"></i> Files
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