function b_load() {
    var req = new JsHttpRequest();
    req.onreadystatechange = function() {
        if (req.readyState == 4) {
	    if(req.responseJS.info){
		document.getElementById('b_info').innerHTML = req.responseJS.info;
	    }
	    if(req.responseJS.news){
		document.getElementById('news').innerHTML = req.responseJS.news;
	    }
	    if(req.responseJS.c_form){
		document.getElementById('c_form').innerHTML = req.responseJS.c_form;
	    }
        }
    }
    req.loader = 'SCRIPT';
    req.open(null, '/basket/ajax.php?action=load', true);
    req.send();
} 
function b_order(form){
    var req = new JsHttpRequest();
    var value = get_form(form);
    req.onreadystatechange = function() {
        if (req.readyState == 4) {
	    if(req.responseJS.text){
		var msg = document.getElementById('div_msg');
		msg.innerHTML = req.responseJS.text;
		msg.style.cssText = req.responseJS.css;
	    }
	    else {
		window.location='/basket/';
	    }
        }
    }
    req.open(null, '/basket/ajax.php?action=order', true);
    req.send(value);
}
function b_country(c){
    var req = new JsHttpRequest();
    var d  = document.getElementById('div_payment');
    document.body.style.cursor = 'wait';
    req.onreadystatechange = function() {
	if (req.readyState == 4) {
	    if(req.responseJS.html){
		d.innerHTML = req.responseJS.html;
		document.body.style.cursor = 'default';
	    }
	}
    }
    req.open(null, '/basket/ajax.php?action=set_c&c='+c, true);
    req.send();
}
function b_payment(c,p){
    var req = new JsHttpRequest();
    var d  = document.getElementById('div_amount');
    document.body.style.cursor = 'wait';
    req.onreadystatechange = function() {
	if (req.readyState == 4) {
	    if(req.responseJS.html){
		d.innerHTML = req.responseJS.html;
		document.body.style.cursor = 'default';
	    }
	    var inf  = document.getElementById('div_pay_info');
	    if(req.responseJS.info){
		inf.innerHTML = req.responseJS.info;
		//inf.style.cssText = 'display: block;';
	    }
	    else {
		inf.innerHTML = '';
		//inf.style.cssText = 'display: none;';
	    }
	}
    }
    req.open(null, '/basket/ajax.php?action=set_p&c='+c+'&p='+p, true);
    req.send();
}
function b_add(form) {
    var req = new JsHttpRequest();
    var value = get_form(form);
    req.onreadystatechange = function() {
        if (req.readyState == 4) {
            var msg = document.getElementById('div_msg');
	    msg.innerHTML = req.responseJS.text;
	    msg.style.cssText = req.responseJS.css;
	    if(req.responseJS.info){
		document.getElementById('b_info').innerHTML = req.responseJS.info;
	    }
	    if(req.responseText){
		document.getElementById('debug').innerHTML = req.responseText;
	    }
        }
    }
    req.open(null, '/basket/ajax.php?action=add', true);
    req.send(value);
} 
function b_info() {
    var req = new JsHttpRequest();
    var b  = document.getElementById('b_info');
    req.onreadystatechange = function() {
        if (req.readyState == 4) {
	    if(req.responseJS.info){
		b.innerHTML = req.responseJS.info;
	    }
        }
    }
    req.loader = 'SCRIPT';
    req.open(null, '/basket/ajax.php?action=info', true);
    req.send();
} 
function b_del(i) {
    var req = new JsHttpRequest();
    var b  = document.getElementById('b_info');
    req.onreadystatechange = function() {
        if (req.readyState == 4) {
	    if(req.responseJS.info){
		b.innerHTML = req.responseJS.info;
	    }
        }
    }
    req.loader = 'SCRIPT';
    req.open(null, '/basket/ajax.php?action=del&i='+i, true);
    req.send();
} 
function c_login(form) {
    var req = new JsHttpRequest();
    var value = get_form(form);
    req.onreadystatechange = function() {
        if (req.readyState == 4) {
	    if(req.responseJS.msg){
		var msg = document.getElementById('div_msg');
		msg.innerHTML = req.responseJS.msg;
		msg.style.cssText = req.responseJS.css;
	    }
	    if(req.responseJS.html){
		document.location.reload();
		//var d = document.getElementById('c_form');
		//d.innerHTML = req.responseJS.html;
	    }
        }
    }
    req.open(null, '/basket/ajax.php?action=login', true);
    req.send(value);
} 
function c_logout() {
    var req = new JsHttpRequest();
    req.onreadystatechange = function() {
        if (req.readyState == 4) {
	    if(req.responseJS.html){
		document.location.reload();
		//var d = document.getElementById('c_form');
		//d.innerHTML = req.responseJS.html;
	    }
        }
    }
    req.open(null, '/basket/ajax.php?action=logout', true);
    req.send();
} 
