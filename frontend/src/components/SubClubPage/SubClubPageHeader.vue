<template>
  <article>
    <head>
      <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
      <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
      <meta http-equiv="X-UA-Compatible" content="ie=edge"/>
    </head>
    <body>
      <main>
        <div class="header">
            <div class="logo">
                <a href="#" class="logo">Interest Club</a>
            </div>
            <div class="search">
              <button type="submit"><i class="fa fa-search"></i></button>
              <input type="text" placeholder="Search clubs, sub-clubs and people">
            </div>
            <div class="icons">
              <button class="btn"><i class="fa fa-home" ></i></button>
              <button class="btn" @click=" ()=>$router.push('/private_message')"><i class="fa fa-comment"></i></button>
              <button class="btn"><i class="fa fa-user"></i></button>
            </div>
            <div class="chevron-down">
              <span class="chevron-down-btn" ><i class="fa fa-chevron-down"></i></span>
              <div class="dropdown-content">
                <ul>
                  <li><p>Signed in as {{userFirstName}}</p></li> 
                  <li><button @click=" ()=>$router.push('/profile_page')">Profile</button></li>
                  <li><button @click=" ()=>$router.push('/support_page')">Support</button></li>
                  <li><button @click=" ()=>$router.push('/')">Log Out</button></li>  
                </ul>
              </div>
            </div>
        </div>
  
      </main> 
    </body>
  </article>
</template>

<script>
  export default {
    data() { 
      return{
        user:{ 
          id:1,
	    		username:"bandit",
          email:"basak945@gmail.com",
          subclubs:[{ 
            id:1,
	    		  name:"Yoga",
	    		  img: require("@/assets/sub-clubs-images/Yoga.jpeg")
	    	  },
	        {
            id:2,
	    		  name: "Piano",
            img:require("@/assets/sub-clubs-images/Piano.jpeg")}]
	    	}
      }
    },
    computed:{
        userFirstName(){
           return this.$store.getters.getUserFirstName
        },
    },
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">  
@import url('https://fonts.googleapis.com/css2?family=Alegreya+Sans:wght@500&display=swap');
    * {
      font-family:'Alegreya Sans', sans-serif;
    }
    .header {
      grid-area: header;
      display: grid; 
      grid-template-columns: 30fr 30fr 30fr 3fr;
      grid-template-areas: "logo search icons chevron-down";
    }
    main{
        height: 50px;
        display: grid;
        grid-template-columns: 1fr;
        grid-template-rows: 1fr 10fr;
        grid-template-areas:"header"
        "." ;
    }
    .header{
        background: white;
        border-bottom:0.3em solid #a56a9d;
        
    }
    .icons{
      grid-area: icons;
      align-items: end;
      justify-self: end;
      display: grid;
      grid-auto-flow: column;
      grid-column-gap: 2rem;
    }
    /*.subclub-list{
      grid-area: subclublist;
    } */
    .search{
      display: grid;
      grid-area: search;
      justify-self: center;
      margin-bottom: 1%;
      align-self: center;
      grid-auto-flow: column;
      input:focus{
        outline:none;
      }
      input[type="text"]{
        margin-right: 50%;
        width: 100%;
        border:none;
        height: 170%;
        background: #f1ecf1;
        padding-left: 4%;
        color: #000;
      }
      button[type="submit"]{
        color: #a56a9d;
        height: 170%;
        border: none;
        background: #f1ecf1;
      }
    }
    ::placeholder{
      color: black;
      opacity: 1;
    }
    .chevron-down{
      grid-area: chevron-down;
      justify-self: start;
      align-self: center;
      margin-bottom: 30%;
      z-index:1000;
    }
    .chevron-down-btn{
      background-color: transparent; 
      border: none; 
      color: #a56a9d;
      font-size: 80%;
      cursor: pointer; 
      
    }
    .dropdown-content ul li {
      list-style-type: none;
      border-bottom: 0.1rem solid #a56a9d;
      color: black;
      display: flex;
      justify-content: center;
      
      button{ 
        text-decoration: none;
        color:#742957;
        border:none;
        background-color:#f9f9f9;
        cursor: pointer;
      }
      p{
        padding-left:10px;
        
      }
      
    }
    .dropdown-content {
      display: none;
      position: absolute;
      background-color: #f9f9f9;
      margin-left: -5%;
      border-radius: 1em;
      border: 0.2em solid #a56a9d;
      margin-top: -1%;
      ul{
        display:flex;
        flex-direction: column;
        justify-content: center;
        padding:1%;
        align-self: center;
      }
      
     
    }
    .chevron-down:hover .dropdown-content {
      display: flex;
      justify-content: center;
    }
    .btn{
      background-color: transparent; 
      border: none; 
      color: #a56a9d;
      font-size: 250%;
      cursor: pointer; 
    }
    .logo{
      grid-area: logo;
      align-self: center;
      margin-left: 10%;
    }
    .logo a{
      text-decoration: none;
      color:#742957;
      font-size: 1.8em;
      font-weight: 700;
    }
    /*.big-box{
        background: white;
    } */
    @media screen and (max-width:700px){
      .search{
        max-width: 100%;
        overflow: hidden;
      }
    }
</style>