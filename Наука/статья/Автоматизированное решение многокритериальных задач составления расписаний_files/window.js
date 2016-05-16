function cover_view(){
    var cover = document.getElementById('img_cover');
    var canvas = document.getElementById('div_cover_canvas');
    var w = parseInt(cover.getAttribute("width"));
    var h = parseInt(cover.getAttribute("height"));
    cover.onclick = function(event){
	event = event || window.event
	if (event.preventDefault) {  
	    event.preventDefault();
	} else { // вариант IE<9:
	    event.returnValue = false;
	}
	var offset = getOffset(canvas);
        var win = document.createElement('div');
        var overlay = document.createElement('div');
        overlay.className = 'win_overlay';
        win.className = 'win';
        var img = new Image();
	img.className = 'win_img';
	img.onload = function(){
	    img.style.height = img.height + 'px';
	    img.style.width  = img.width + 'px';
	    win.style.top = offset.top - 60 + 'px';
	    win.style.left = offset.left + 45 +  w - img.width +'px';
	    win.style.height = img.height + 'px';
	    win.style.width  = img.width + 'px';
	    var el = document.documentElement;
	    overlay.style.height = Math.max(el.scrollHeight, el.clientHeight) + 'px';
	    overlay.style.width = Math.max(el.scrollWidth, el.clientWidth) + 'px';
	    canvas.appendChild(overlay);
	    overlay.appendChild(win);
	    win.appendChild(img);
	}
        img.src = cover.href;
        overlay.onclick = function(e){
            canvas.removeChild(overlay);
        };
    };
}
function getOffset(elem) {
    if (elem.getBoundingClientRect) {
        return getOffsetRect(elem)
    } else {
        return getOffsetSum(elem)
    }
}
function getOffsetSum(elem) {
    var top=0, left=0
    while(elem) {
        top = top + parseInt(elem.offsetTop)
        left = left + parseInt(elem.offsetLeft)
        elem = elem.offsetParent
    }
    return {top: top, left: left}
}
function getOffsetRect(elem) {
    var box = elem.getBoundingClientRect()
    var body = document.body
    var docElem = document.documentElement
    var scrollTop = window.pageYOffset || docElem.scrollTop || body.scrollTop
    var scrollLeft = window.pageXOffset || docElem.scrollLeft || body.scrollLeft
    var clientTop = docElem.clientTop || body.clientTop || 0
    var clientLeft = docElem.clientLeft || body.clientLeft || 0
    var top  = box.top +  scrollTop - clientTop
    var left = box.left + scrollLeft - clientLeft
    return { top: Math.round(top), left: Math.round(left) }
}
