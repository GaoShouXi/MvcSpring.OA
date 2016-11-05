//$(function () {
//    var carId = 1;
//    $.ajax({
//        url: "/UserInfo/GetAllUsers",
//        datatype: 'json',
//        type: "Post",
//        data: "id=" + carId,
//        success: function (data) {
//            if (data != null) {
//                $.each(eval("(" + data + ")").list, function (index, item) { //遍历返回的json
//                    trs = '<tr>'+'<td>' + item.Id + '</td>' + '<td>' + item.UserName + '</td>' + '<td>' + item.PassWord + '</td>' + '<td>' + item.ShowName + '</td>' + '<td>' + item.Modfiedon + '</td>' + '<td>' + item.Remark + '</td>' + '</tr>'
//                            $("#example2").append(trs);

//                });
//$(function () {
//    $.ajax({
//        url: "/UserInfo/GetAllUsers",
//        datatype: 'json',
//        type: "Post",

//        success: function (data) {
//          
          
//        }
//    })
// 
//});
                
//if (data != null) {
//    var trs = "";
//    $.each(eval("(" + data + ")").list, function (index, item) { //遍历返回的json

//        trs = '<tr>'+'<td>' + item.Id + '</td>' + '<td>' + item.UserName + '</td>' + '<td>' + item.PassWord + '</td>' + '<td>' + item.ShowName + '</td>' + '<td>' + item.Modfiedon + '</td>' + '<td>' + item.Remark + '</td>' + '</tr>'
//        $("#example2").append(trs);
//    });          
	    
	           


//}
//"bStateSave": true, //是否打开客户端状态记录功能,此功能在ajax刷新纪录的时候不会将个性化设定回复为初始化状态
//              "bJQueryUI": true, //是否使用 jQury的UI theme
//              "sScrollY": 450, //DataTables的高
//              "sScrollX": 820, //DataTables的宽
//              "aLengthMenu": [5, 10, 20], //更改显示记录数选项
//              "iDisplayLength": 5, //默认显示的记录数
//              "bAutoWidth": false, //是否自适应宽度
//              "bScrollInfinite" : false, //是否启动初始化滚动条
//              "bScrollCollapse": true, //是否开启DataTables的高度自适应，当数据条数不够分页数据条数的时候，插件高度是否随数据条数而改变
//              "bPaginate": true, //是否显示（应用）分页器
//              "bInfo": true, //是否显示页脚信息，DataTables插件左下角显示记录数
//              "sPaginationType": "full_numbers", //详细分页组，可以支持直接跳转到某页
//              "paging":true,
//              "bSort": true, //是否启动各个字段的排序功能
//              "aaSorting": [[1, "asc"]], //默认的排序方式，第2列，升序排列
//              "bFilter": true, //是否启动过滤、搜索功能
//              "aoColumns": [
//              {
//                  "mDataProp": "UserName",
//                  "sTitle": "用户名",
//                  "sDefaultContent": "",
//                  "sClass": "center"
//              }, {
//                  "mDataProp": "Password",
//                  "sTitle": "密码",
//                  "sDefaultContent": "",
//                  "sClass": "center"
//              }, {
//                  "mDataProp": "ShowName",
//                  "sTitle": "昵称",
//                  "sDefaultContent": "",
//                  "sClass": "center"
//              }, {
//                  "mDataProp": "DelFlag",
//                  "sTitle": "删除标识",
//                  "sDefaultContent": "",
//                  "sClass": "center"
//              }, {
//                  "mDataProp": "SubTime",
//                  "sTitle": "修改时间",
//                  "sDefaultContent": "",
//                  "sClass": "center"
//              }, {
//                  "mDataProp": "Modfiedon",
//                  "sTitle": "注册时间",
//                  "sDefaultContent": "",
//                  "sClass": "center"
//              }, {
//                  "mDataProp": "Remark",
//                  "sTitle": "备注",
//                  "sDefaultContent": "",
//                  "sClass": "center"
//              }
//              ],
//              "oLanguage": { //国际化配置
//                  "sProcessing": "正在获取数据，请稍后...",
//                  "sLengthMenu": "显示 _MENU_ 条",
//                  "sZeroRecords": "没有您要搜索的内容",
//                  "sInfo": "从 _START_ 到  _END_ 条记录 总记录数为 _TOTAL_ 条",
//                  "sInfoEmpty": "记录数为0",
//                  "sInfoFiltered": "(全部记录数 _MAX_ 条)",
//                  "sInfoPostFix": "",
//                  "sSearch": "搜索",
//                  "sUrl": "",
//                  "oPaginate": {
//                      "sFirst": "第一页",
//                      "sPrevious": "上一页",
//                      "sNext": "下一页",
//                      "sLast": "最后一页"
//                  }
//              },