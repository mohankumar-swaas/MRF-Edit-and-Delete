


var edit = 0;

$(document).ready(function () {
  
    loadData();
});
function loadData(Userid) {
    var Userid = $('#txtUserid').val();
    
    

    $.ajax({
        url: "/User/List?Userid="+ Userid,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';

            $.each(result, function (key, item) {

                html += '<tr>';
                
                html += '<td>' + item.Userid + '</td>';
                html += '<td>' + item.PositionName + '</td>';
                html += '<td>' + item.VacancyField + '</td>';
                html += '<td>' + item.TerritoryHQ + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.id + ')">Edit</a > | <a href="#" onclick="Delete(' + item.id + ')">Delete</a></td > ';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
    
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function Delete(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/User/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}
function getbyID(id) {
   
    edit = 1;
    
    window.location.href = "/MRF/EditMRF?id=" + id + "&edit="+edit;
    
}

function EditMRF(id) {
    alert("hello");
    Userid = id;
   

        $.ajax({
            url: "/User/GetbyID/" + id,
            type: "GET",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                $('#id').val(result.id);
                $('#PositionName').val(result.PositionName);
                $('#MRF_Created_By').val(result.Created_By);
                var date = result.MRF_Created_Date;
                var nowdate = new Date(parseInt(date.substr(6)));
                $('#MRF_Created_Date').val(nowdate.toISOString().substring(0, 10));
                var beforedate = result.Position_to_be_filled_before;
                var Positiontobefilledbefore = new Date(parseInt(beforedate.substr(6)));
                $('#Position_to_be_filled_before').val(Positiontobefilledbefore.toISOString().substring(0, 10));
                $('input:radio[id="Fielduser"][value=' + result.Vacancy_For + ']').attr('checked', true)
                $('input:radio[id="Vacancy Type"][value=' + result.Vacancy_Type + ']').attr('checked', true)
                $('#TerritoryHQ').val(result.TerritoryHQ);
                $('#DivisionName').val(result.DivisionName);
                $('#Min_yrs').val(result.Min_Yrs);
                $('#Max_yrs').val(result.Max_yrs);
                $('#MinCTC').val(result.MinCTC);
                $('#MaxCTC').val(result.MaxCTC);
                $('#Additional_Requirement').val(result.Additional_Requirement);

                $('#btnUpdate').show();
                $('#btnAdd').hide();

            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
        return false;
    
}

function Update() {
   
    var MRFObj = {
        id: Userid,
        PositionName: $('#PositionName').val(),
        MRF_Created_By: $('#MRF_Created_By').val(),
        MRF_Created_Date: $('#MRF_Created_Date').val(),
        Position_to_be_filled_before: $('#Position_to_be_filled_before').val(),
        Vacancy_For: $('input[name="radiovacancy"]:checked').val(),
        Vacancy_Type: $('input[name="vacancy"]:checked').val(),
        TerritoryHQ: $('#TerritoryHQ').val(),
        DivisionName: $('#DivisionName').val(),
        Min_Yrs: $('#Min_yrs').val(),
        Max_yrs: $('#Max_yrs').val(),
        MinCTC: $('#MinCTC').val(),
        MaxCTC: $('#MaxCTC').val(),
        Additional_Requirement: $('#Additional_Requirement').val(),
    };
    $.ajax({
        url: "/User/Update",
        data: JSON.stringify(MRFObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            loadData();
            
            $('#result').html('Record Updated Successfully!');

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

