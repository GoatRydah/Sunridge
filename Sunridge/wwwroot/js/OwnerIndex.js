var dataTable;

$(document).ready(function () {
    LoadList();
});

function LoadList() {
    dataTable = $('#DT_Load').DataTable({
        "ajax": {
            "url": "/api/ownerIndex/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "firstName", "width": "11%" },
            { "data": "lastName", "width": "11%" },
            { "data": "userName", "width": "11%" },
            { "data": "emergencyContactName", "width": "11%" },
            { "data": "emergencyContactPhone", "width": "11%" },
            { "data": "ownerLots", "render": function (data) {
                return "stuff";
                }, "width": "11%"
            },
            {
                "data": "id",
                "render": function (data) {
                    return ` <div class="text-center">
                                <a href="/identity/account/resetPassword?code=${data}" class="btn btn-info text-white" style="cursor:pointer; width:100px;">
                                    <i class="far fa-edit"></i> Edit
                                </a>
                                <a href="/identity/account/upsert?id=${data}" class="btn btn-success text-white" style="cursor:pointer; width:160px;">
                                    <i class="fas fa-lock-open"></i> Reset Password
                                </a>
                                <a class="btn btn-danger text-white" style="cursor:pointer; width:100px;" onClick=Delete('/api/ownerIndex/${data}')>
                                    <i class="far fa-trash-alt"></i> Delete
                                </a>
                             </div>`;
                }, "width": "34%"
            }
        ],
        "language": {
            "emptyTable": "no data found."
        },
        "width": "100%"
    });
}

function Delete(url) {
    console.log("made it");
    swal({
        title: "Are you sure you want to delete?",
        text: "User will be removed!",
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