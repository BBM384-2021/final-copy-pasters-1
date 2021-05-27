<template>
            <div><SubClubPageHeader/></div>
            <div class="my-subclubs">
            <div class="main">
                <h2>My Sub-Clubs</h2>
            <form class="subclub-form" action="#">
                <div class="subclub" v-for="club in userSubClubs" :key="club">
                    <div class="image-div">
                        <router-link class="select-subclub" :to="`/sub_club_page/${club.title}`"><img class="subclub-image" :src="club.imgUrl"></router-link> 
                        <div class="text">{{club.title}}</div>
                    </div>
                </div>
                <div class="wrapper">
                    <router-link @click="updateCurrentSubClubName" :to="'/join_more_sub_clubs/'"><img class="more" src="~@/assets/background.jpeg"></router-link> 
                    <div class="text">Join more <br>sub-clubs...<br></div>
                </div>
            </form>
            </div>
        </div>
</template>

<script>
import SubClubPageHeader from '../components/SubClubPage/SubClubPageHeader.vue';
export default{
    components:{
        SubClubPageHeader,
    },
    data(){
        return{
        user:{ 
            id:1,
	        username:"bandit",
            email:"basak945@gmail.com",
            subclubs:[{ 
                    id:1,
	    		    name:"Yoga",
	    		    img: require("../assets/sub-clubs-images/Yoga.jpeg")
            },
	        {
                    id:2,
	    		    name: "Piano",
                    img:require("../assets/sub-clubs-images/Piano.jpeg")}]
	    }
      }
    },
    computed:{
        userSubClubs(){
            return this.$store.getters.getUserSubClubs
        }
    },
    methods:{
        getImgUrl(imgUrl){
            return require(imgUrl)
        },

    }

}
</script>

<style scoped lang="scss">
@import url('https://fonts.googleapis.com/css2?family=Alegreya+Sans:ital@1&display=swap');
.main{
    display: grid;
    grid-template-rows: 1fr 10fr;
    grid-template-areas:"title"
                        "subclubs";        
}
h2{
    grid-area: title;
    align-self: center;
    margin-left: 5%;
    margin-top: 2%;
    font-size: 200%;
    font-family: 'Alegreya Sans', sans-serif;
    font-weight: 500;
}
.subclub-form{
    grid-area: subclubs;
    overflow-y:auto;
}
.text{
    position: absolute;
    top: 55%;
    left: 25%;
    transform: translate( -50%, -50% );
    text-align: center;
    color: white;
    font-weight:600;
    font-size: 300%;
    font-family: 'Alegreya Sans', sans-serif;
    -webkit-text-stroke: 1px black; /* width and color */
}
.subclub{
    position: relative;
    
}
img{
    width: 70%;
    margin-left: 15%;
    margin-top: 2%;
    height: 15em;
    border-radius: 2em;
    border:0.2em solid rgb(137, 109, 138);
    overflow: hidden;
    object-fit:cover;
    
}
.select-subclub:hover, a:hover{
    color: #000;
    img{
        margin-top: 2.5%;
    }
}
.wrapper{
    position: relative;
}
slot[name=my-subclubs]{
    overflow: auto;
} 
@media all and (max-width: 425px){
    img{
        height: 5em;
    }
}
@media all and (max-width: 768px){
    .text{
         font-size: 200%;
    }
}
@media all and (max-width: 425px){
    .text{
         font-size: 100%;
    }
}
</style>
