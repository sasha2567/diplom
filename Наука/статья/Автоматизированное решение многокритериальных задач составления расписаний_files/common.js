function r_pass(form) {
    var req = new JsHttpRequest();
    if(form){
	var value = get_form(form);
    }
    else {
	var value = null;
    }
    req.onreadystatechange = function() {
        if (req.readyState == 4) {
	    if(req.responseJS.msg){
		var msg = document.getElementById('div_msg');
		msg.innerHTML = req.responseJS.msg;
		msg.style.cssText = req.responseJS.css;
	    }
	    if(req.responseJS.html){
		var d = document.getElementById('c_form');
		d.innerHTML = req.responseJS.html;
	    }
        }
    }
    req.open(null, '/basket/ajax.php?action=r_pass', true);
    req.send(value);
} 
function get_form(form){
   var queryText = new Array();
   for (var k = 0, lim = form.elements.length; k<lim; k++)
   {
     var v = form.elements[k];
     var tn = (v.tagName != undefined ? v.tagName.toUpperCase() : '');
     if (tn == 'INPUT' || tn == 'TEXTAREA' || tn == 'SELECT')
     {
       var type = v.type.toLowerCase();
       if (type=='radio' && !v.checked) continue;
       else if (type=='file' && v.value) {
	   queryText[v.name] = v;
	   continue;
	}
       var val = (type=='checkbox') ? ((v.checked==true) ? v.value : "") : v.value;
       queryText[v.name] = val;
     }
   }
   return queryText;
 }
function like_init(){
    VK.init({apiId: 2156516, onlyWidgets: true});
    VK.Widgets.Like("vk_like", {type: "button"});
    fr = document.createElement("iframe");
    fr.setAttribute("frameBorder","0");
    fr.setAttribute("width","220");
    fr.setAttribute("height","21");
    fr.src = 'http://www.facebook.com/plugins/like.php?href=http://www.dslib.net&layout=button_count&show_faces=true&width=220&action=like&font=arial&colorscheme=light&height=21';
    fr.style.cssText = 'border-style: none; border:none; overflow:hidden; width:220px; height:21px; background-color:transparent;';
    fr.scrolling = 'no';
    fr.allowTransparency = true;
    e = document.createElement('script');
    e.src = 'http://cdn.connect.mail.ru/js/loader.js';
    document.getElementById('fb_like').appendChild(fr);
    document.getElementById('mr_like').appendChild(e);
}
function div_display(div,value){
    var popup = document.getElementById(div);
    if(value !== undefined){
	popup.style.display = value;
    }
    else if(popup.style.display =='none' ){
	popup.style.display = 'block'
    }
    else{
	popup.style.display = 'none'
    }
}
function search_ext_load(div){
    var d = document.getElementById(div)
    if(d.style.display =='none' ){
	var req = new JsHttpRequest();
	document.body.style.cursor = 'wait';
	req.onreadystatechange = function() {
	    if (req.readyState == 4) {
		if(req.responseJS.html){
		    d.innerHTML = req.responseJS.html;
		    document.body.style.cursor = 'default';
		    d.style.display = 'block'
		}
	    }
	}
	req.open(null, '/search/ext.php', true);
	req.send();
    }
    else{
	d.style.display = 'none'
    }
}
function search_ext_save(form){
    var form = document.getElementById(form);
    if(form){
	var value = get_form(form);
	var req = new JsHttpRequest();
	req.onreadystatechange = function() {
	    if (req.readyState == 4) {
		if(req.responseJS.stat){
		    return true;
		}
	    }
	}
	req.open(null, '/search/ext.php?action=save', true);
	req.send(value);
    }
    else {
	return true;
    }
}
function search_ext_idx(form) {
    var obj = document.getElementById(form).idx;
    if(!obj) return;
    if(obj.checked) {
	obj.checked = false;
    }
    else {
	obj.checked = true;
    }
}
function search_ext_v(form,newValue) {
    var radioObj = document.getElementById(form).v;
    if(!radioObj)
	    return;
    var radioLength = radioObj.length;
    if(radioLength == undefined) {
	radioObj.checked = (radioObj.value == newValue.toString());
	return;
    }
    for(var i = 0; i < radioLength; i++) {
	radioObj[i].checked = false;
	if(radioObj[i].value == newValue.toString()) {
	    radioObj[i].checked = true;
	}
    }
}
function get_item_cont(id) {
    var req = new JsHttpRequest();
    req.onreadystatechange = function() {
        if (req.readyState == 4) {
	    if(req.responseJS.html){
		var d = document.getElementById('item_cont_div');
		d.innerHTML = req.responseJS.html;
	    }
        }
    }
    req.open(null, '/search/ext.php?action=get_cont&id='+id, true);
    req.send(null);
} 
function req_load(div,form_id,type){
    var form = document.getElementById(form_id);
    var value = get_form(form);
    var d = document.getElementById(div);
    if(d.style.display =='none' ){
	var req = new JsHttpRequest();
	document.body.style.cursor = 'wait';
	req.onreadystatechange = function() {
	    if (req.readyState == 4) {
		if(req.responseJS.html){
		    d.innerHTML = req.responseJS.html;
		    document.body.style.cursor = 'default';
		    d.style.display = 'block'
		}
	    }
	}
	if(type == undefined){
	    req.open(null, '/basket/ajax.php?action=req_load', true);
	}
	else if(type == 'msg'){
	    req.open(null, '/author/ajax.php?action=msg_load', true);
	}
	req.send(value);
    }
    else{
	document.body.style.cursor = 'default';
	d.style.display = 'none'
    }
}
function req_send(div,form_id,type,box){
    var form = document.getElementById(form_id);
    var value = get_form(form);
    var d = document.getElementById(div);
    var req = new JsHttpRequest();
    document.body.style.cursor = 'wait';
    req.onreadystatechange = function() {
	if (req.readyState == 4) {
	    if(req.responseJS.msg){
		var msg = document.getElementById('div_msg');
		msg.innerHTML = req.responseJS.msg;
		msg.style.cssText = req.responseJS.css;
		d.style.display = 'none'
	    }
	    document.body.style.cursor = 'default';
	    if(type == 'req' && (typeof req.responseJS.html != 'undefined')){
		var b = document.getElementById(box);
		if(b != null){
		    b.innerHTML = req.responseJS.html;
		}
	    }
	}
    }
    if(type == undefined || type == 'req'){
	req.open(null, '/basket/ajax.php?action=req_send', true);
    }
    else if(type == 'msg'){
	req.open(null, '/author/ajax.php?action=msg_send', true);
    }
    req.send(value);
}
function ajax_query(url,box_name,data){
    var method = 'GET';
    if(data == undefined) data = null;
    else method = 'POST';
    var box = document.getElementById(box_name);
    var req = new JsHttpRequest();
    document.body.style.cursor = 'wait';
    req.onreadystatechange = function() {
        if (req.readyState == 4) {
	    document.body.style.cursor = 'default';
	    if(req.responseJS.msg){
		var msg = document.getElementById('div_msg');
		msg.innerHTML = req.responseJS.msg;
		msg.style.cssText = req.responseJS.css;
	    }
	    if(req.responseJS.html){
		box.innerHTML = req.responseJS.html;
	    }
        }
    }
    req.open(method, url, true);
    req.send(data);
}
function cat_sub(code,action){
    if(code == undefined || code == '') return false;
    var url = '/subs/ajax.php?action=cat_'+action+'&code='+code;
    ajax_query(url,'cat_sub_div');
}
function item_sub(id,type,action){
    if(id == undefined || id == '') return false;
    var url = '/subs/ajax.php?action=item_'+action+'&id='+id+'&type='+type;
    ajax_query(url,'item_sub');
}
