<template>
    <div >
        <questionnaire-header class="bar" >  </questionnaire-header>
        <h1 class="h1">Questionnaire</h1>
        <form class="questionnaire" action="#">
            <div class="space" v-for="(question,index_of_question) in questions" :key="index_of_question">
                <div class="question text "> {{question.questionText}}</div>
                    <div class="options-container">
                        <div class="option" v-for="(choice,index_of_choice) in question.choices" :key="index_of_choice">
                            <input class="option-input radio " type="radio" :value="[question.id , choice]" v-model="selected_choices[index_of_question]">
                            <label class="label" :for="choice">
                                <span class="text">{{choice}}</span>
                            </label>
                        </div>       
                    </div>
                
            </div>
            <div class=" button_container">  
                <div class="btn-holder">
                    <button @click="()=>$router.push('/questionnaire_result')" class="submit_button"><span> SUBMIT </span></button>
                </div>
            </div>
            
        </form>
    </div>
</template>

<script>
    import QuestionnaireHeader from "../components/Questionnaire/SubClubSelectionHeader.vue";
    export default {
        components : {
            "questionnaire-header" : QuestionnaireHeader
            },
        name:"Questionnaire",
        data() { return{
            selected_choices:[],
            questions:[
	    	{ 
                id:1,
	    		subclubName:"Yoga",
	    		questionText: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Omnis, hic?", 
	    		choices: ["0-200","200-400","400-600","600+"],
	    		
	    	},
	    	{  
                id:2,
	    		subclubName:"Art",
	    		questionText: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Omnis, hic?", 
	    		choices: ["0-200","200-400","400-600","600+"],
                
	    	},{ 
                id:1,
	    		subclubName:"Yoga",
	    		questionText: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Omnis, hic?", 
	    		choices: ["0-200","200-400","400-600","600+"],
	    		
	    	},
	    	{  
                id:2,
	    		subclubName:"Art",
	    		questionText: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Omnis, hic?", 
	    		choices: ["0-200","200-400","400-600","600+"],
                
	    	},
            { 
                id:1,
	    		subclubName:"Yoga",
	    		questionText: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Omnis, hic?", 
	    		choices: ["0-200","200-400","400-600","600+"],
	    		
	    	},
	    	{  
                id:2,
	    		subclubName:"Art",
	    		questionText: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Omnis, hic?", 
	    		choices: ["0-200","200-400","400-600","600+"],
                
	    	},{ 
                id:1,
	    		subclubName:"Yoga",
	    		questionText: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Omnis, hic?", 
	    		choices: ["0-200","200-400","400-600","600+"],
	    		
	    	},
	    	{  
                id:2,
	    		subclubName:"Art",
	    		questionText: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Omnis, hic?", 
	    		choices: ["0-200","200-400","400-600","600+"],
                
	    	}
	          ]
        }
    },
    
    }
    
</script>

<style scoped lang="scss">
 @import url('https://fonts.googleapis.com/css2?family=Alegreya+Sans:wght@500&display=swap');
    * {
      font-family:'Alegreya Sans', sans-serif;
    }
.question{
    
    display: flex;
    justify-content: space-between;
    border: 3px solid #ba7ea0;
    border-radius: 15px;
    padding:40px;
    margin-top: 15px;
    margin-left: 200px;
    margin-right: 200px;
    
}
.option{
    width:200px;
   /* display: flex;
    align-items: center;*/
    background-color: #ffffff;
    border-radius: 15px;
    border: 3px solid #ba7ea0 ;
    padding:30px;
    margin: 30px;
}
.options-container{
    display: flex;
    justify-content: center;
}
.h1{
  margin-top: 50px;
  margin-left: 240px;
  margin-bottom: 25px;
  color: black;
  font-size: 55px;
  letter-spacing: 1px;
}
.space{
    margin-bottom:150px;
}
.text{
    word-wrap: break-word;
    font-weight:bold;
    font-size: 30px;
}
.submit_button{
    
    background-color: #ba7ea0;
    border-radius: 10px;
    color: #ffffff;
    text-align: center;
    font-size: 28px;
    padding: 20px;
    width: 200px;
    transition: all 0.5s;
    cursor: pointer;
    margin-right:200px;
    position: relative;
    
}
.submit_button span {
    cursor: pointer;
    display: inline-block;
    position: relative;
    transition: 0.5s;
}
.submit_button span:after {
    content: '\00bb';
    position: absolute;
    opacity: 0;
    top: 0;
    right: -20px;
    transition: 0.5s;
}
.submit_button:hover span {
    padding-right: 25px;
}
.submit_button:hover span:after {
    opacity: 1;
    right: 0;
}
.button_container {
    justify-content: space-between;
    flex-direction: column;
    height: 150px;
    display: flex;
  }
  .button_container .btn-holder {
    justify-content: flex-end;
    display: flex;
  }
@keyframes ring {
0% {
    width: 30px;
    height: 30px;
    opacity: 1;
}
100% {
    width: 300px;
    height: 300px;
    opacity: 0;
}
}
@keyframes click-wave {
0% {
    height: 40px;
    width: 40px;
    opacity: 0.35;
    position: relative;
}
100% {
    height: 200px;
    width: 200px;
    margin-left: -80px;
    margin-top: -80px;
    opacity: 0;
}
}
.option-input {
    -webkit-appearance: none;
    -moz-appearance: none;
    -ms-appearance: none;
    -o-appearance: none;
    appearance: none;
    position: relative;
    top: -20px;
    right: 0;
    bottom: 30px;
    left: -20px;
    height: 40px;
    width: 40px;
    transition: all 0.15s ease-out 0s;
    background: #cbd1d8;
    border: none;
    color: #fff;
    cursor: pointer;
    display: inline-block;
    margin-right: 0.5rem;
    outline: none;
    position: relative;
    z-index: 1000;
}
.option-input:hover {
    background: #9faab7;
}
.option-input:checked {
    background: #ba7ea0;
}
.option-input:checked::before {
    height: 40px;
    width: 40px;
    position: absolute;
    content: "✔";
    display: inline-block;
    font-size: 26.66667px;
    text-align: center;
    line-height: 40px;
}
.option-input:checked::after {
    -webkit-animation: click-wave 0.65s;
    -moz-animation: click-wave 0.65s;
    animation: click-wave 0.65s;
    background: #ba7ea0;
    content: '';
    display: block;
    position: relative;
    z-index: 100;
}
.option-input.radio {
    border-radius: 50%;
}
.option-input.radio::after {
    border-radius: 50%;
}
body label {
    line-height: 40px;
}
::v-deep .progress-bar-front{
    width: 68%;
}
</style>