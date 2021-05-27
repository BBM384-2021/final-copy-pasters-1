import { createStore } from 'vuex'

export default createStore({
  state: {
    categories: 
	[	
		{
			name: "Sports",
			sub_clubs: 
			[
			{
				id: 1,
				name: "Basketball",
				questions: 
				[
					{
						id: 1,
						clubId: 1,
						text: "Have you ever watched any Basketball match?",
						choices: ["None", "A few Times", "Sometimes", "Very Often"]
					},
					{
						id: 2,
						clubId: 1,
						text: "Have you ever played Basketball?",
						choices: ["None", "A Few Times", "sometimes", "A lot"]
					},
					{
						id: 3,
						clubId: 1,
						text: "Do you know the rules of Basketball?",
						choices: ["I don't know", "I know a little", "I know enough", "I know very good"]
					},
					{
						id: 4,
						clubId: 1,
						text: "Do you enjoy talking about basketball matches?",
						choices: ["I don't like", "I like", "I enjoy", "I love"]
					},
					{
						id: 5,
						clubId: 1,
						text: "How many players are there in a match in a Basketball team?",
						choices: ["11", "10", "6", "5"]
					}
					
				]
			},
			{
				id: 2,
				name: "Football",
				questions: 
				[
					
					{
						id: 6,
						clubId: 2,
						text: "Have you ever watched any Football match?",
						choices: ["None", "A few Times", "Sometimes", "Very Often"]
					},
					{
						id: 7,
						clubId: 2,
						text: "Do you know the rules of Football?",
						choices: ["I don't know", "I know a little", "I know enough", "I know very good"]
					},
					{
						id: 8,
						clubId: 2,
						text: "Do you enjoy talking about Football matches?", 
						choices: ["I don't like", "I like", "I enjoy", "I love"]
					},
					{
						id: 9,
						clubId: 2,
						text: "How many players are there in a match in a Football team?",
						choices: ["5", "6", "10", "11"]
					},
					{
						id: 10,
						clubId: 2,
						text: "How many Football matches have you ever watched in the stadium?",
						choices: ["0", "1", "2", "3+"]
					},
					
				]
			},
			{
				id: 3,
				name: "Yoga",
				questions: 
				[
					{
						id: 11,
						clubId: 3,
						text: "Do you enjoy doing Yoga?",
						choices: ["I don't like", "I like", "I enjoy", "I love"]
					},
					{
						id: 12,
						clubId: 3,
						text: "Do you find Yoga helpful/relaxing?",
						choices: ["Not At All", "A little", "Quite", "Always"]
					},
					{
						id: 13,
						clubId: 3,
						text: "Have you ever been in a Yoga course",
						choices: ["None", "Once", "More Than One", "A lot"]
					},
					
				]
			},
			{
				id: 4,
				name: "Tennis",
				questions: 
				[
					{
						id: 14,
						clubId: 4,
						text: "Which one is a tennis player?",
						choices: ["Lebron James", "Leonel Messi", "Lewis Hamilton", "Serena Williams"]
					},
					{
						id: 15,
						clubId: 4,
						text: "How is the scores of a tennis match count?",
						choices: ["0-1-2-3-win", "0-3-6-9-win", "0-15-30-45-win", "0-15-30-40-win"]
					},
					{
						id: 16,
						clubId: 4,
						text: "Have you ever watched any Tennis match?",
						choices: ["None", "A few Times", "Sometimes", "Very Often"]
					},
					{
						id: 17,
						clubId: 4,
						text: "Do you know the rules of Tennis?",
						choices: ["I don't know", "I know a little", "I know enough", "I know very good"]
					},
					{
						id: 18,
						clubId: 4,
						text: "Do you like talking about Tennis?",
						choices: ["I don't like", "I like", "I enjoy", "I love"]
					},

				]
			},
			{
				id: 5,
				name: "Swimming",
				questions: 
				[
					{
						id: 19,
						clubId: 5,
						text:"How would you describe your level of Swimming?", 
						choices: ["I don't know", "Beginner", "Adequate", "Professional"]
					},
					{	
						id: 20,
						clubId: 5,
						text:"Do you enjoy Swimming?", 
						choices: ["I don't like", "I like", "I enjoy", "I love"]
					},
					{
						id: 21,
						clubId: 5,
						text:"Have you ever watched any Swimming competition?", 
						choices: ["None", "A few Times", "Sometimes", "Very Often"]
					},
					{
						id: 22,
						clubId: 5,
						text:"Do you like talking about Swimming?", 
						choices: ["I don't like", "I like", "I enjoy", "I love"]
					}
				]
			}
			]
		},
		{
			name: "Music",
			sub_clubs:
			[
			{
				id: 6,
				name: "Violin",
				questions: 
				[
					{
						id: 23,
						clubId: 6,
						text:"How would you describe your interest in playing the Violin?", 
						choices: ["None", "A little", "Quite", "A Lot"]
					},
					{
						id: 24,
						clubId: 6,
						text:"Do you like listening instrumental musics (especially Violin)?", 
						choices: ["I don't like", "I like", "I enjoy", "I love"]
					},
					{
						id: 25,
						clubId: 6,
						text:"How would you describe your level of playing the Violin?", 
						choices: ["I don't know", "Beginner", "Adequate", "Professional"]
					},
					{
						id: 26,
						clubId: 6,
						text:"Do you like listening to classical musics?", 
						choices: ["Not At All", "A little", "Often", "Always"]
					},

				]
			},
			{
				id: 7,
				name: "Piano",
				questions: 
				[
					{
						id: 27,
						clubId: 7,
						text: "How would you describe your level of playing the Piano?", 
						choices: ["I don't know", "Beginner", "Adequate", "Professional"]
					},
					{
						id: 28,
						clubId: 7,
						text: "Which one is NOT a musical note?", 
						choices: ["B", "C", "G", "H"]
					},
					{
						id: 29,
						clubId: 7,
						text: "How would you describe your interest in playing the Piano?", 
						choices: ["None", "A little", "Quite", "A Lot"]
					},
					{
						id: 30,
						clubId: 7,
						text: "Do you like listening instrumental musics (especially Piano)?", 
						choices: ["I don't like", "I like", "I enjoy", "I love"]
					},
				]
			},
			{
				id: 8,
				name: "Guitar",
				questions: 
				[
					{
						id: 31,
						clubId: 8,
						text: "How would you describe your interest in playing the Guitar?", 
						choices: ["None", "A little", "Quite", "A Lot"]
					},
					{
						id: 32,
						clubId: 8,
						text: "How many strings are there in a typical Guitar?", 
						choices: ["4", "7", "5", "6"]
					},
					{
						id: 33, 
						clubId: 8,
						text: "How would you describe your level of playing the Guitar?", 
						choices: ["I don't know", "Beginner", "Adequate", "Professional"]
					},
					{
						id: 34,
						clubId: 8,
						text: "Do you like listening instrumental musics (especially Guitar)?", 
						choices: ["I don't like", "I like", "I enjoy", "I love"]
					},
				]
			},
			{
				id: 9,
				name: "Electronic Music",
				questions: 
				[
					{
						id: 35,
						clubId: 9,
						text: "How old are you?", 
						choices: ["older than 50", "41-50", "30-40", "younger than 30"]
					},
					{
						id: 36,
						clubId: 9,
						text: "How would you describe yourself, introvert or extrovert?", 
						choices: ["extrovert", "closer to extrovert", "closer to introvert", "introvert"]
					},
				]
			}
			]	
		},
		{
			name: "Visual Arts",
			sub_clubs:
			[
			{
				id: 10,
				name: "Painting",
				questions:
				[
					{
						id: 37,
						clubId: 10,
						text: "How would you describe your mastery of Painting?", 
						choices: ["Novice", "Beginner", "Proficient", "Expert"]
					},
					{
						id: 38,
						clubId: 10,
						text: "Have you ever taken any Painting course?", 
						choices: ["None", "1-2 times", "2-4 times", "More than 4 times"]
					},
					{
						id: 39,
						clubId: 10,
						text: "Which one is NOT a Painter?",
						choices: ["Pablo Picasso", "Vincent Van Gogh", "Edvard Munch", "Frédéric Chopin"]
					},
					{
						id: 40,
						clubId: 10,
						text: "How many paintings have you ever bought?",
						choices: ["None", "1-3", "3-6", "6+"]
					},
					
				]
			},
			{
				id: 11,
				name: "Drawing",
				questions:
				[
					{
						id: 41,
						clubId: 11,
						text: "How would you describe your mastery of Drawing?",
						choices: ["Novice", "Beginner", "Proficient", "Expert"]
					},
					{
						id: 42,
						clubId: 11,
						text: "Have you ever drawn someone (sketching)?",
						choices: ["None", "Once", "Twice", "More than two"]
					},
					{
						id: 43,
						clubId: 11,
						text: "Do you like talking about Drawing?",
						choices: ["I don't like", "I like", "I enjoy", "I love"]
					},
				]
			},
			{
				id: 12,
				name: "Photography",
				questions:
				[
					{
						id: 44,
						clubId: 12,
						text: "How would you describe your knowledge of photography (tecniques, concepts etc.)?",
						choices: ["Novice", "Beginner", "Proficient", "Expert"]
					},
					{
						id: 45,
						clubId: 12,
						text: "Do you like talking about Photography?",
						choices: ["I don't like", "I like", "I enjoy", "I love"]
					},
					{
						id: 46,
						clubId: 12,
						text: "Do you like taking photographs when you travel?",
						choices: ["I don't like", "I like", "I enjoy", "I love"]
					},
				]
			},
			]
		},
		{
			name: "Hobbies",
			sub_clubs: 
			[
			{
				id: 13,
				name: "Puzzle",
				questions:
				[
					{
						id: 47,
						clubId: 13,
						text: "Do you enjoy solving problems?",
						choices: ["I don't like", "I like", "I enjoy", "I love"]
					},
					{
						id: 48,
						clubId: 13,
						text: "Do you like to put things in order?",
						choices: ["None", "A little", "Often", "Always"]
					},
					{
						id: 49,
						clubId: 13,
						text: "How many puzzles have you ever solved (completed)?",
						choices: ["0", "1-2", "2-4", "4+"]
					},
					{
						id: 50,
						clubId: 13,
						text: "8. Do you enjoy building/assembling things?",
						choices: ["Not At All", "A little", "Quite", "Always"]
					},
					
				]
			},
			{
				id: 14,
				name: "Sudoku",
				questions:
				[
					{
						id: 51,
						clubId: 14,
						text:"Would you describe yourself an analytical person?",
						choices: ["Not At All", "A little", "Often", "Always"]
					},
					{
						id: 52,
						clubId: 14,
						text:"Do you enjoy solving math problems?",
						choices: ["I don't like", "I like", "I enjoy", "I love"]
					},
					{
						id: 53,
						clubId: 14,
						text:"Do you know the rules of Sudoku?",
						choices: ["I don't know", "I know a little", "I know enough", "I know very good"]
					},
					{
						id: 54,
						clubId: 14,
						text:"How many cells are there in a sudoku grid?",
						choices: ["36", "121", "100", "81"]
					},
					
				]
			},
			{
				id: 15,
				name: "Reading",
				questions:
				[
					{
						id: 55,
						clubId: 15,
						text: "How many pages do you read a day?",
						choices: ["0", "0-40", "40-100", "100+"]
					},
					{
						id: 56,
						clubId: 15,
						text: "Do you enjoy talking about books?", 
						choices: ["I don't like", "I like", "I enjoy", "I love"]
					},
					{
						id: 57,
						clubId: 15,
						text: "How many books have you read in your life?",
						choices: ["0-10", "10-50", "50-100", "100+"]
					},
					{
						id: 58,
						clubId: 15,
						text: "Which one is NOT a book?",
						choices: ["Crime and Punishment", "A Tale of Two Cities", "The Sorrows of Young Werther", "Pulp Fiction"]},
				]
			},
			{
				id: 16,
				name: "Cooking",
				questions:
				[
					{
						id: 59,
						clubId: 16,
						text: "Do you like to go out for dinner?",
						choices: ["I love", "I enjoy", "I like", "I don't like"]
					},
					{
						id: 60,
						clubId: 16,
						text: "Have you ever cooked for your friends?",
						choices: ["None", "Once", "A few times", "A lot"]
					},
					{
						id: 61,
						clubId: 16,
						text: "How many dinner recipes do you know?",
						choices: ["None", "1-5", "5-10", "10+"]
					},
					{
						id: 62,
						clubId: 16,
						text: "Have you ever cooked a dessert, and was it delicious?",
						choices: ["No, No", "Yes, No", "Yes, Not Bad", "Yes, Delicious"]},
				]
			},
			{
				id: 17,
				name: "Chess",
				questions:
				[
					{
						id: 63,
						clubId: 17,
						text: "Do you enjoy solving problems?",
						choices: ["I don't like", "I like", "I enjoy", "I love"]
					},
					{
						id: 64,
						clubId: 17,
						text: "Do you know the rules of Chess?", 
						choices: ["I don't know", "I know a little", "I know enough", "I know very good"]
					},
					{
						id: 65,
						clubId: 17,
						text: "Which one is NOT a grandmaster?",
						choices: ["Magnus Carlsen", "Garry Kasparov", "Bobby Fischer", "Friedrich Engels"]
					},
					{
						id: 66,
						clubId: 17,
						text: "How would you describe your level of playing Chess?",
						choices: ["I don't know", "Beginner", "Adequate", "Professional"]
					},
				]
			},
			
			]
		}
		
	],
    active: [],
    selected_sub_clubs: [],
	selected_questions: [],
	selected_choices: [],
	question_count: {},
	analyze_results: {},
    //current user
    user:{ 
      id:1,
      username:"bandit",
      email:"basak945@gmail.com",
      subclubs:[{ 
          id:1,
          name:"Yoga",
          img: require("../assets/sub-clubs-images/Yoga.jpeg"),
          rate: 3.2,
          about:"This is about yoga subclub"
        },
      {
          id:2,
          name: "Piano",
          img:require("../assets/sub-clubs-images/Piano.jpeg"),
          rate:4.0,
          about:"This is about piano subclub"
      }]
 
    },    
 
  },
  mutations: {
    makeActive(state, category){
      const index = state.active.indexOf(category)
      if (index >= 0)
          state.active.splice(index,1)
      else
          state.active.push(category)
    },
    addSubClub(state,sub_club){
      const index = state.selected_sub_clubs.indexOf(sub_club)
      if (index < 0)
          state.selected_sub_clubs.push(sub_club)
		  state.question_count[sub_club.id] = 0
		  state.analyze_results[sub_club.id] = 0
		  sub_club.questions.forEach(element => {
		  	  state.selected_questions.push(element)
			  state.question_count[sub_club.id] += 1
		  })
    },
    removeSubClub(state, sub_club){

      const index = state.selected_sub_clubs.indexOf(sub_club)
      if (index >= 0)
          state.selected_sub_clubs.splice(index,1)
		  state.selected_questions.splice(index,1)
    },
	addChoice (state, ch){
		state.selected_choices.push(ch)
	},
	analyzeQuestions(state){
		
		state.selected_choices.forEach(element => {
			var id = element[0];
			var choice = element[1];
			state.analyze_results[id] += parseInt(choice)
		});
		
		for(var id in state.analyze_results){
			var res = parseInt(state.analyze_results[id]);
			var count = parseInt(state.question_count[id]);
			if(parseInt(res) >= (parseInt(count)/2))
				state.analyze_results[id] = parseInt((res/(count*3))*100)
			else
				state.analyze_results[id] = parseInt((res/(count*3))*100)
		}
		console.log(state.analyze_results)
	}
  },
  actions: {

  },
  modules: {
  },
  getters:{
    getSubClubs(state){
      return state.subclubs.filter(s => s.name)
    }
  }



})