//根据QueryString参数名称获取值
function getQueryStringByName(name) {
	var result = location.search.match(new RegExp("[\?\&]" + name + "=([^\&]+)", "i"));
	if (result == null || result.length < 1) {
		return "";
	}
	return result[1];
}
function getFileName(fileName) {
	return fileName.substring(0, fileName.lastIndexOf("."));
}
function getSuffix(fileName) {
	//return /\.[^\.]+/.exec(fileName);
	var nIndex1 = fileName.lastIndexOf(".");
	var nIndex2 = fileName.length;
	return fileName.substring(nIndex1 + 1, nIndex2).toLowerCase();
}
function getFileFormatImage(strSuffix) {
	if (strSuffix == "doc" || strSuffix == "docx")
		return "/content/images/file_doc.png";
	if (strSuffix == "wps")
		return "/content/images/file_wps.png";
	if (strSuffix == "pdf")
		return "/content/images/file_pdf.png";
	if (strSuffix == "rar")
		return "/content/images/file_rar.png";
	if (strSuffix == "zip")
		return "/content/images/file_zip.png";
	else
		return "/content/images/file_unkown.png";
}
function getFormJsonData(id) {
	if (id == undefined)
		id = "FormObj";
	return $("[" + id + "]").serialize();
}
//通用数据提交方法
function ajaxRequest(_url, _data, _success, _error) {
	$.ajax({
		type: "POST", url: _url, data: _data, dataType: "json",
		success: function (res) {
			_success(res);
		},
		error: function (XMLHttpRequest, textStatus, errorThrown) {
			if (undefined != _error && null != _error)
				_error(XMLHttpRequest, textStatus, errorThrown);
			else
				alert("提交出现错误：" + textStatus);
		}
	});
}
//汇付天下提交方法
function pnrRequest(_url, _data, _success, _error) {
	$.ajax({
		type: "POST", url: _url, data: _data, dataType: 'html',
		success: function (res) {
			_success(res);
		},
		error: function (XMLHttpRequest, textStatus, errorThrown) {
			if (undefined != _error && null != _error)
				_error(XMLHttpRequest, textStatus, errorThrown);
			else
				alert("提交出现错误：" + textStatus);
		}
	});
}
function isInt(_val) {
	if ("" == _val)
		return false;
	var re = /^([1-9]+\d{0,8})$/;
	return (re.test(_val));
}
function isNumber(_val) {
	if ("" == _val)
		return false;
	var re = /^([1-9]+\d{1,8}\.*[0-9]{0,2})$/;
	return (re.test(_val));
}
function isEmail(_email) {
	if ("" == _email)
		return false;
	var re = /^(?:\w+\.?)*\w+@(?:\w+\.)*\w+$/;
	return (re.test(_email));
}
function isMobile(_mobile) {
	if ("" == _mobile)
		return false;
	var re = /^1\d{10}$/;
	return (re.test(_mobile));
}
function isDate(_date) {
	var reg = /^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2})$/;
	var result = _date.match(reg);
	if (null == result)
		return false;
	var dt = new Date(result[1], result[3] - 1, result[4]);
	if (Number(dt.getFullYear()) != Number(result[1]))
		return false;
	if (Number(dt.getMonth()) + 1 != Number(result[3]))
		return false;
	if (Number(dt.getDate()) != Number(result[4]))
		return false;
	return true;
}


var art = {
    alert: function (msg, callback) {
        var nr = '<div style="text-align:center;">' + msg + '<br><br><button type="button" class="btn btn-primary" data-dismiss="modal">确定</button></div>';
        art.showWindow('消息提示', nr, callback);
    },
    showWindow: function (title, nr, callback) {
        if (callback == undefined || callback == null) {
            callback = function (e) { }
        }
        if ($('#mymsgbox').length < 1) {
            var html = '<div class="modal fade" id="mymsgbox" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">' +
						'<div class="modal-dialog">' +
						'<div class="modal-content">' +
						'<div class="modal-header">' +
						'<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>' +
						'<h4 class="modal-title">' + title + '</h4>' +
						'</div>' +
						'<div class="modal-body">' + nr + '</div>' +
						'</div>' +
						'</div>' +
						'</div>';
            $('body').append(html);
        } else {
            $('#mymsgbox .modal-title').html(title);
            $('#mymsgbox .modal-body').html(nr);
        }
        $('#mymsgbox').modal('show');
        $('#mymsgbox').on('hidden.bs.modal', callback);
    }
}