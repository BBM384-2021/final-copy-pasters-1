<template>
<header-helper>
</header-helper>
    <div>
    <div class="main">
        <div class="image-header">
            <img class="subclub-image" :src="require('@/assets/sub-clubs-images/'+currentSubClub.title+'.jpeg')">
            <div class="subclub-name">
                <h1>{{currentSubClub.title}}</h1>     
                <img class="star-img" src="~@/assets/star.png">
                <p id="main-rate">{{currentSubClub.averageRate}}</p>    
            </div>
            </div>
            <div v-if="show" class="big-box-member">
                <div class="timeline-members-chatroom-event-ratereview">
                    <div class="tab">                      
                        <button id="_1" class="tablinks" @click="switchTo('Members')">Members</button>
                        <button id="_2" class="tablinks" @click="switchTo('Chat Room')">Chat Room</button>
                        <button id="_3" class="tablinks" @click="switchTo('Events')">Events</button>
                        <button id="_4" class="tablinks" @click="switchTo('Rate&Review')">Rate&#38;Review</button>    
                    </div>
                    <event v-if="eventsShow"></event>
                    <members v-if="membersShow"></members>
                    <rate-and-review v-if="rateAndReviewShow"></rate-and-review>
                    <chat-room v-if="chatRoomShow"></chat-room>
                </div>
            </div>
            <div v-else class="big-box-not-member">
                <div class="about">
                    <p id="about">About</p>
                    <div class="about-text"><p id="subclub-about">{{currentSubClub.about}}</p></div>
                </div>
                <div class="rate-review">
                    <p id="rate-review">Ratings&#38;Reviews</p>
                    <div class="rate-review-outer">
                        <div class="rates-review-text" v-for="rates_reviews in currentSubClub.rates_reviews" :key="rates_reviews">
                            <p id="rate">{{rates_reviews.rate}}</p>
                            <div class="review-text"><p id="subclub-review">{{rates_reviews.review}}</p></div>
                        </div>
                    </div>
                </div>
            </div> 
        </div>
    </div>
</template>

<script>
import header from '../components/SubClubPage/SubClubPageHeader.vue'
import events from '../components/SubClubPage/Events.vue'
import members from '../components/SubClubPage/Members.vue'
import rateAndReview from '../components/SubClubPage/RateAndReview.vue'
import chatRoom from '../components/ChatRoom/ChatRoom.vue'
export default{
    components:{
        'header-helper':header,
        'event': events,
        'members':members,
        'rate-and-review':rateAndReview,
        'chat-room':chatRoom
    },
    data(){
        return{
            subClubName: this.$route.params.subclubname,
            membersShow:true,
            chatRoomShow:false,
            eventsShow:false,
            rateAndReviewShow:false,
        }
    },
    computed:{
        show(){
            let isMember = false
            for(let i = 0; i < this.$store.getters.getUserSubClubs.length; i++){
                if(this.$store.getters.getUserSubClubs[i].title == this.$route.params.subclubname){
                    isMember = true
                    break 
                }
            }
            return isMember
        },
        currentSubClub(){
           for(let i = 0; i < this.$store.getters.getSubClubs.length; i++){
                if(this.$store.getters.getSubClubs[i].title == this.$route.params.subclubname){
                    return this.$store.getters.getSubClubs[i]
                }
            }
            return this.$store.getters.getSubClubs[0] 
        },
    },
    methods:{
        getImgUrl(imgUrl){
            return require(imgUrl)
        },
        
        switchTo(div_name){
            if(div_name=='Members'){
                this.membersShow = true
                this.chatRoomShow =false
                this.eventsShow = false
                this.rateAndReviewShow = false
            }
            if(div_name=='Events'){
                this.membersShow = false
                this.chatRoomShow =false
                this.eventsShow = true
                this.rateAndReviewShow = false
            }
            if(div_name=='Chat Room'){
                this.membersShow = false
                this.chatRoomShow =true
                this.eventsShow = false
                this.rateAndReviewShow = false
            }
            if(div_name=='Rate&Review'){
                this.membersShow = false
                this.chatRoomShow =false
                this.eventsShow = false
                this.rateAndReviewShow = true
            }
        }

    }
    
}

</script>

<style scoped lang="scss">
@import url('https://fonts.googleapis.com/css2?family=Alegreya+Sans:ital,wght@0,400;0,500;0,700;0,800;1,400;1,500;1,700&display=swap');

.main{
    display: grid;
    grid-template-rows: 10rem 1fr;
    font-family: 'Alegreya Sans', sans-serif;
    
   /* grid-template-areas:"imageHeader"
                        "bigBox";       */ 
}

.image-header{
    margin-top: 0.3%;
    grid-area: imageHeader;
    position: relative;
    grid-row: 1/2;
    grid-column: 1/2;
}


p#main-rate{
    position: relative;
    top: -2.5em;
    left: 1.5%;
    font-size: 150%;
}

img{
    width:100%;
    height:100%;
    object-fit:cover;
}

.subclub-name{
    position: relative;
    top: -50%;
    left: 5%;
    transform: translate( -50%, -50% );
    text-align: center;
    color: white;
    font-weight:500;
}

.big-box-not-member{
    //grid-area: bigBox;
    grid-row: 2/3;
    grid-column: 1/2;
    display: grid;
    grid-template-rows: 20% 60% 1fr;
    grid-template-columns: 1fr 70% 1fr;
    grid-template-areas:". about ."
                        ". rateReview ."
                        ". joinSubclub .";
}

.big-box-member{
    overflow: auto;
}


button#_1{
    grid-area: button1;
}
button#_2{
    grid-area: button2;
}
button#_3{
    grid-area: button3;
}
button#_4{
    grid-area: button4;
}


.tab{
    overflow: hidden;
    display: grid;
    grid-template-columns: 1fr 1fr 1fr 1fr;
    grid-template-rows: 1fr;
    grid-template-areas: "button1 button2 button3 button4";
   // margin-left: 5%;
}



.tab button{
    background-color: inherit;
    border:hotpink;
    color: rgb(175, 150, 179);
    border: 1px solid rgb(245, 219, 227);
    font-weight: 500;
    cursor: pointer;
    padding: 1% 4%;
    transition: 0.3s; 
    font-size: xx-large;
}

.tab button:hover {
  background-color: rgb(166, 105, 172);
  color: white;
}




.timeline-members-chatroom-event-ratereview{
    grid-area: timelineMembersChatRoomEventsRateReview;
    height: 50em;
    border-radius: 2em;
    margin-top: 5%;
    margin-right: 5%;
    margin-left: 5%;
    border: 0.2em solid rgb(245, 219, 227);
    justify-self: center;
    overflow: auto;
   
}

.about{
    grid-area: about;
    justify-items: start;
    display: grid;
    grid-template-rows: 1fr 1fr;
    grid-template-areas:"aboutP"
                        "aboutDiv";
}

p#about{
    grid-area: aboutP;
    align-self: center;
    font-size: 150%;
    margin-bottom: -4%;
}

.about-text{
    grid-area: aboutDiv;
    display: flex;
    align-items: center;
    justify-content: center;
    background-color: #f5e7f3;
    width: 100%;
    height: 70%;
    text-align: center;
    border-radius: 1rem;
}

p#subclub-about{
    display: table;
    font-size:150%;
    background-color:white;
    color:black;
    width: 90%;
    height: 60%;
    border-radius: 0.7rem;
    padding: 1%;
}

.rate-review{
    grid-area: rateReview; 
    display: grid;
    grid-template-rows: 1fr 10fr;
    grid-template-areas:"rateReviewTitle"
                        "rateReviewDiv";

}

.rate-review-outer{
    grid-area: rateReviewDiv;
    background-color: #f5e7f3;
    height: 150%;
    overflow: auto;
    border-radius: 1rem;
     margin-top: 5%;
}

.rates-review-text{
    margin-left: 5%;
}

p#rate{
    position: relative;
    top: 2em;
    left: 1.5%;
    margin-bottom: 1%;
}

p#subclub-review{
    display: table;
    font-size:120%;
    background-color:white;
    color:black;
    width: 98%;
    height: 3em;
    border-radius: 1rem;
    padding: 1%;
    
}


.review-text{
    position: relative;
    top: 2em;
}

p#rate-review{
    grid-area: rateReviewTitle;
    align-self: center;
    font-size: 150%;
    margin-bottom: -1%;
}

.join-subclub{
    grid-area: joinSubclub; 
    display: grid;
    margin-top: 5%;
    grid-template-rows: 10% 10%;
    grid-template-areas: "join"
                        "button"; 
   
}

p#join{
    grid-area: join;
    font-size: 150%;
}

.apply{
    grid-area: button;
    justify-self: center;
    align-self: center;
    width: 50%;
    height: 300%;
    background: #b983b1;
    border:none;
    border-radius: 1rem;
    color: white;
    font-size: 150%;
    margin-top: 10%;

}

.star-img{
    width: 2%;
    position: relative;
    top: 120%;
    left: -1%;
  
}  




ul li{
    
    
    display: inline;
    margin-right:1em;
    margin-top:-1.5em;
 
}


@media all and (max-width: 768px){

    p#main-rate{
        font-size: 50%;
    }
    .apply{
        font-size: 100%;
        margin-bottom: -25%;
    }
    .tab button{
        font-size: x-large;
    }
    
}


</style>
