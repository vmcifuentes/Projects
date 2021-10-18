// Seleccionamos elementos de la UI 
const title = document.getElementById("title");
const start = document.getElementById("start");
const quiz = document.getElementById("quiz");
const question = document.getElementById("question");
const questionImg = document.getElementById("questionImg");
const choiceA = document.getElementById("a"); 
const choiceB = document.getElementById("b");
const choiceC = document.getElementById("c");
const counter = document.getElementById("counter");
const timeCauge = document.getElementById("timeCauge");
const progress = document.getElementById("progress");
const scoreContainer = document.getElementById("scoreContainer");

// Definición de preguntas (object array)
let questions = [
    {
        question : 	"En JS, ¿cómo escribimos una cadena de texto en la página Web?",
        imgSrc : 	"imas/question_0.png",
        choiceA : 	"document.write('Hola mundo!')",
        choiceB : 	"document.print('Hola mundo!')",
        choiceC : 	"window.write('Hola mundo!')",
        correct : 	"a"
    },{
        question : 	"¿JavaScript es un lenguaje de programación...?",
        imgSrc : 	"imas/question_1.png",
        choiceA : 	"Compilado",
        choiceB : 	"Interpretado",
        choiceC : 	"Estructurado",
        correct : 	"b"
    },{
        question : 	"¿Dónde se puede insertar código JavaScript en páginas Web?",
        imgSrc : 	"imas/question_2.png",
        choiceA : 	"En head",
        choiceB : 	"En body",
        choiceC : 	"Tanto en head como en body",
        correct : 	"c"
    },{
    	question : 	"¿Cómo abrimos una nueva ventana o pestaña en JS?",
        imgSrc : 	"imas/question_3.png",
        choiceA : 	"window.new('new.html')",
        choiceB : 	"document.new('new.html')",
        choiceC : 	"window.open('new.html')",
        correct : 	"c"
    },{
    	question : 	"¿Cómo obtenemos la versión del navegador con JS?",
        imgSrc : 	"imas/question_4.png",
        choiceA : 	"navigator.appVersion",
        choiceB : 	"navigator.version",
        choiceC : 	"browser.appVersion",
        correct : 	"a"
    }
];

// Variables globales de la App
const lastQuestion = questions.length - 1;
let runningQuestion = 0;
let count = 0;
const questionTime = 10; // 10s
const gaugeWidth = 150; // 150px
const gaugeUnit = gaugeWidth / questionTime;
let TIMER;
let score = 0;

// Función para render de preguntas
const renderQuestion = ()=>{
    let q = questions[runningQuestion];
    question.innerHTML = "<p>"+ q.question +"</p>";
    questionImg.innerHTML = "<img src="+ q.imgSrc +">";
    choiceA.innerHTML = q.choiceA;
    choiceB.innerHTML = q.choiceB;
    choiceC.innerHTML = q.choiceC;
}

// Función para iniciar el Quiz
const startQuiz = () =>{
    start.style.display = "none";
    title.style.display = "none";
    renderQuestion();
    quiz.style.display = "block";
    
    renderProgress();
    renderCounter();
    TIMER = setInterval(renderCounter,1000); // 1000ms = 1s
}

start.addEventListener("click",startQuiz);


// Función para render del Progress
const renderProgress = () =>{
    for(let qIndex = 0; qIndex <= lastQuestion; qIndex++){
        progress.innerHTML += "<div class='prog' id="+ qIndex +"></div>";
    }
}

// Función para render del contador (tiempo)
const renderCounter = () =>{
    if(count <= questionTime){
        counter.innerHTML = count;
        timeGauge.style.width = count * gaugeUnit + "px";
        count++
    }else{
        count = 0;
        // Indica progreso y coloca 'malo' (rojo)
        answerIsWrong();
        if(runningQuestion < lastQuestion){
            runningQuestion++;
            renderQuestion();
        }else{
            // Finaliza el quiz y muestra el punteo
            clearInterval(TIMER);
            scoreRender();
        }
    }
}


// Función para chequear respuestas
const checkAnswer = answer =>{
	if( answer == questions[runningQuestion].correct){
		// La respuesta es correcta
        score++;
		// Indica progreso y coloca 'bueno' (verde)
		answerIsCorrect();
    }else{
		// La respuesta es incorrecta
		// Indica progreso y coloca 'malo' (rojo)
		answerIsWrong();
    }
    count = 0;

	if(runningQuestion < lastQuestion){
        runningQuestion++;
		renderQuestion();
    }else{
		// Finaliza el quiz y muestra el punteo
		clearInterval(TIMER);
		scoreRender();
    }
}













// Función para determinar estilos de respuestas correctas
const answerIsCorrect =()=>{
	const strStyle = "background-color:#3cbd56;border-color:#3cbd56";
	document.getElementById(runningQuestion).style.cssText = strStyle;
}

// Función para determinar estilos de respuestas incorrectas
const answerIsWrong =()=>{
	const strStyle = "background-color:#f00;border-color:#f00;"
	document.getElementById(runningQuestion).style.cssText = strStyle;
}

// Función para renderizar el punteo
const scoreRender=()=>{
	scoreContainer.style.display = "block";
	
	// Calcula cantidad de preguntas % respondidas por el usuario
	const PERFECT_SCORE = 100;
	const scorePerCent = Math.round(PERFECT_SCORE * score/questions.length);
	
	// Elegimos imagen basada en el porcentaje de punteo obtenido
	let ima = (scorePerCent >= 80) ? "imas/5.png" :
              (scorePerCent >= 60) ? "imas/4.png" :
              (scorePerCent >= 40) ? "imas/3.png" :
              (scorePerCent >= 20) ? "imas/2.png" : "imas/1.png";
	
	scoreContainer.innerHTML = "<img src="+ ima +">";
	scoreContainer.innerHTML += "<p>"+ scorePerCent +"%</p>";
	scoreContainer.innerHTML += "<button id='restart' onclick='restart()'><i class='fas fa-chevron-circle-left'></i> Regresar</button>";
}

// Función para reiniciar el quiz
const restart = ()=>{
	location.reload();
}







