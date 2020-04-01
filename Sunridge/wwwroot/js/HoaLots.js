//var editor;

//$(document).ready(function () {
//    LoadList();
//});

//function LoadList() {
//    editor = new $.fn.dataTable.Editor({
//        ajax: "/api/ownerIndex/",
//        table: "#DT_Load",
//        fileds: [{
//            label: "Lot Number:",
//            name: "Lot.LotNumber"                                     //lot table
//        }, {
//            label: "Street Address:",
//            name: "Address.StreetAddress"                             //address table
//        }, {
//            label: "Username:",
//            name: "ApplicationUser.UserName"                          //application user table            //0, 1 or 2 values
//        }, {
//            label: "Tax ID:",
//            name: "Lot.TaxId"                                         //lot table
//        }, {
//            label: "Lot Inventory:",
//            name: "LotInventory.Description"                          //lot inventory table               //0, 1 or many values
//        }
//        ]
//});


//    $('#DT_Load').DataTable({

//        ajax: "/api/ownerIndex/",
//        dom: 'Bfrtip',
//        columns: [
//            { data: "Lot.LotNumber", width: "15%" },                  //lot table
//            { data: "Address.StreetAddress", width: "15%" },          //address table
//            { data: "ApplicationUser.UserName", width: "15%" },       //application user table            //0, 1 or 2 values
//            { data: "Lot.TaxId", width: "15%" },                      //lot table         
//            { data: "LotInventory.Description", width: "15%" },       //lot inventory table                //0, 1 or many values                    
//            {
//                "data": "id",
//                    "render": function (data) {
//                        return ` <div class="text-center">
//                                                <a href="/admin/hOALots/upsert?id=${data}" class="btn btn-info text-white" style="cursor:pointer; width:100px;">
//                                                    <i class="far fa-edit"></i> Edit
//                                                </a>
//                                                <a href="/admin/hOALots/filesIndex" class="btn btn-dark text-white" style="cursor:pointer; width:100px;">
//                                                    <i class="far fa-file-alt"></i> Files
//                                                </a>
//                                                </div>`;
//            }, "width": "25%"
//        }],
//    language: {
//    emptyTable: "no data found."
//    },
//    width: "100%"
//});

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
                "data": "lotId",
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