const questions = [
    {
        question: "What is the capital of France?",
        answers: [
            { text: "Paris", value: 1 },
            { text: "London", value: 0 }
        ]
    },
    {
        question: "Which planet is known as the Red Planet?",
        answers: [
            { text: "Earth", value: 0 },
            { text: "Mars", value: 1 },
            { text: "Jupiter", value: 0 }
        ]
    },
    {
        question: "What is the largest ocean on Earth?",
        answers: [
            { text: "Atlantic Ocean", value: 0 },
            { text: "Indian Ocean", value: 0 },
            { text: "Pacific Ocean", value: 1 },
            { text: "Arctic Ocean", value: 0 }
        ]
    },
    {
        question: "Who painted the Mona Lisa?",
        answers: [
            { text: "Leonardo da Vinci", value: 1 },
            { text: "Pablo Picasso", value: 0 }
        ]
    },
    {
        question: "What is the tallest mammal?",
        answers: [
            { text: "Elephant", value: 0 },
            { text: "Giraffe", value: 1 },
            { text: "Horse", value: 0 },
            { text: "Whale", value: 0 }
        ]
    },
    {
        question: "Which country is known as the Land of the Rising Sun?",
        answers: [
            { text: "China", value: 0 },
            { text: "Japan", value: 1 },
            { text: "Korea", value: 0 },
            { text: "India", value: 0 }
        ]
    }
];

let currentQuestionIndex = 0;
let totalProficiencyLevel = 0;

function calculateProficiency(score) {
    if (score < 3) {
        return "Bad";
    } else if (score >= 3 && score < 5) {
        return "Average";
    } else if (score >= 5 && score < 7) {
        return "Good";
    } else {
        return "Great";
    }
}

// Example usage:
const score = 7; // Change this to your actual score
const proficiencyLevel = calculateProficiency(score);
console.log("Proficiency Level:", proficiencyLevel);


function showQuestion(index) {
    const questionText = document.getElementById('question-text');
    const answerButtons = document.getElementById('answer-buttons');
    const prevButton = document.getElementById('prev-button');
    const pagination = document.getElementById('pagination');

    questionText.innerText = questions[index].question;
    answerButtons.innerHTML = '';

    questions[index].answers.forEach(answer => {
        const button = document.createElement('button');
        button.innerText = answer.text;
        button.classList.add('answer-btn');
        button.addEventListener('click', () => {
            selectAnswer(answer.value);
        });
        answerButtons.appendChild(button);
    });

    prevButton.style.visibility = index > 0 ? 'visible' : 'hidden';

    // Update pagination
    pagination.innerHTML = '';
    for (let i = 0; i < questions.length; i++) {
        const circle = document.createElement('div');
        circle.classList.add('circle');
        if (i === index) {
            circle.classList.add('highlight');
        }
        pagination.appendChild(circle);
    }
}

function selectAnswer(value) {
    totalProficiencyLevel += value;

    if (currentQuestionIndex < questions.length - 1) {
        currentQuestionIndex++;
        showQuestion(currentQuestionIndex);
    } else {
        showResult(totalProficiencyLevel);
    }
}

function showResult(score) {
    const gradeText = document.getElementById('grade');
    const proficiencyLevel = calculateProficiency(score);
    gradeText.innerText = proficiencyLevel;
    const resultContainer = document.getElementById('result-container');
    resultContainer.style.display = 'block';
}

function getResult(score) {
    return calculateProficiency(score);
}

function prevQuestion() {
    if (currentQuestionIndex > 0) {
        currentQuestionIndex--;
        showQuestion(currentQuestionIndex);
    }
}

function restartQuiz() {
    currentQuestionIndex = 0;
    totalProficiencyLevel = 0;
    showQuestion(currentQuestionIndex);
    document.getElementById('result-container').style.display = 'none';
}

function leaveQuiz() {
    // Handle leaving quiz, if needed
}

document.addEventListener('DOMContentLoaded', () => {
    showQuestion(currentQuestionIndex);
});
