import { createStore } from 'vuex'

export default createStore({
  state: {
    categories: [
      {name:'Sports', sub_clubs:[
          {name: 'Basketball'},
          {name: 'Football'},
          {name: 'Yoga'},
          {name: 'Tennis'},
          {name: 'Swimming'},
      ]},
      {name:'Music', sub_clubs:[
          {name: 'Violin'},
          {name: 'Piano'},
          {name: 'Guitar'},
          {name: 'Rock Music'},
      ]},
      {name:'Visual Arts', sub_clubs:[
          {name: 'Painting'},
          {name: 'Drawing'},
          {name: 'Ceramics'},
          {name: 'Photography'},
      ]},
      {name:'Hobbies', sub_clubs:[
          {name: 'Puzzle'},
          {name: 'Sudoku'},
          {name: 'Reading'},
          {name: 'Cooking'},
          {name: 'Chess'},
      ]}
    ],
    active: [],
    selected_sub_clubs: [],
    new_sub_clubs: [{name: 'Electronic Music'},{name: 'Sculpture'}],

    //current user
    user:{ 
      id:0,
      firstName:"user1",
      email:"basak945@gmail.com",
      subclubs:[{ 
          id:1,
          title:"Yoga",
          imgUrl: require("../assets/sub-clubs-images/Yoga.jpeg"),
          averageRate: 3.2,
          about:"This is about yoga subclub"
        },
      {
          id:2,
          title: "Piano",
          imgUrl:require("../assets/sub-clubs-images/Piano.jpeg"),
          averageRate:4.0,
          about:"This is about piano subclub"
      },{ 
        id:3,
        title:"Puzzle",
        imgUrl: require("../assets/sub-clubs-images/Puzzle.jpeg"),
        averageRate: 3.2,
        about:"This is about puzzle subclub"
      },]
 
    },
    
    //all sub-clubs
    subclubs:[{
      id:1,
      title:"Yoga",
      imgUrl: "../assets/sub-clubs-images/Yoga.jpg",
      averageRate: 3.2,
      about:"This is about yoga subclub",
      rates_reviews:[{
              rate: 3,
              review: "not bad",
              },
              {
              rate: 5,
              review: "very good",
              },
              {
              rate: 5,
              review: "very good",
              },
              {
                rate: 5,
                review: "very good",     
                },
                {
                  rate: 5,
                  review: "very good",     
                  },]
      },{
      id:2,
      title:"Piano",
      imgUrl: "../assets/sub-clubs-images/Piano.jpg",
      averageRate: 4,
      about:"This is about Piano subclub",
      rates_reviews:[{
              rate: 3,
              review: "not bad",
              },
              {
              rate: 5,
              review: "very good",
              },
          ]}, 
      { 
        id:3,
        title:"Puzzle",
        imgUrl: "../assets/sub-clubs-images/Puzzle.jpeg",
        averageRate: 3.2,
        about:"This is about puzzle subclub",
        rates_reviews:[{
          rate: 3,
          review: "not bad",
          },
          {
          rate: 5,
          review: "very good",
          },
      ]
      },
    ],
    
    
 
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
    },
    removeSubClub(state, sub_club){
      const index = state.selected_sub_clubs.indexOf(sub_club)
      if (index >= 0)
          state.selected_sub_clubs.splice(index,1)
    },
  },
  actions: {
   
  },
  modules: {
  },
  getters:{
    getSubClubs(state){
      return state.subclubs.filter(s => s.title)
    },

    getUserSubClubs(state){
      return state.user.subclubs.filter(s => s.title)
    },

    getUserFirstName(state){
      return state.user.firstName
    }
  }

})
