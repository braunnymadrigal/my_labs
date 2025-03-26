function agregar() {
	var lastElem = document.querySelector("ul li:last-child");
	var newElem = document.createElement ("li");
	var lastNumber = 1;
	
	if(lastElem != null) {
		var lastContent = lastElem.textContent;
		lastNumber = Number(lastContent.substr(8, lastContent.length)) + 1;
	}

	var newContent = document.createTextNode("Elemento" + lastNumber);
	newElem.appendChild(newContent);
	document.querySelector("ul").appendChild(newElem);
}


function cambiarFondo() {
	var fullBodyElem = document.querySelector("body");
	var fullBodyColor = window.getComputedStyle(fullBodyElem).backgroundColor;
	if (fullBodyColor == "rgba(0, 0, 0, 0)") {
		fullBodyElem.style.backgroundColor = "rgba(255, 126, 193, 1)";  // nice pink
	} else {
		fullBodyElem.style.backgroundColor = "rgba(0, 0, 0, 0)";
	}
}


function borrar() {
	var lastElem = document.querySelector("ul li:last-child");
	if (lastElem != null) {
		lastElem.remove();
	}
}

