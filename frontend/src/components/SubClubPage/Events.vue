<template>
<div class="wrapper">
    <div class="first_column">
        <h1>Event at the Planning Stage </h1>
        <div class="planning_stage_events" v-for="event in planning_stage_events" :key="event">
            <div class="event">
                <p>Subject: <a>{{event.subject}}</a> </p>
                <p>when2meet Link:</p> 
                <a href="url">{{event.invitationLink}}</a>   
            </div>
        </div>
    </div>
     <div class = "vertical"></div>
    <div class="second_column">
        <h1>Upcoming Events </h1>
            <div class="up_coming_events" v-for="event in up_coming_events" :key="event">
                <div class="event">
                <p>Type: <a>online</a> </p>
                <p>Subject: <a>{{event.subject}}</a> </p>
                <p>Date: <a>{{event.date}}</a></p>  
                <p>Platform:  <a>{{event.platform}}</a></p> 
                <p>Invitation Link:</p>
                <a href="url">{{event.invitationLink}}</a>   
            </div>
        </div>
    </div>
</div>
</template>

<script>
export default {
    data() { 
        return{
            up_coming_events:[
            {
                id: 0,
                type: "string",
                subject: "string",
                date: "2021-05-26T14:41:11.583Z",
                platform: "string",
                invitationLink: "string",
                subClubId: 0
            },
             {
                id: 0,
                type: "string",
                subject: "string",
                date: "2021-05-26T14:41:11.583Z",
                platform: "string",
                invitationLink: "string",
                subClubId: 0
            },
            {
                id: 0,
                type: "string",
                subject: "string",
                date: "2021-05-26T14:41:11.583Z",
                platform: "string",
                invitationLink: "string",
                subClubId: 0
            },
             {
                id: 0,
                type: "string",
                subject: "string",
                date: "2021-05-26T14:41:11.583Z",
                platform: "string",
                invitationLink: "string",
                subClubId: 0
            }],

            planning_stage_events:[
                {
                    id: 0,
                    type: "string",
                    subject: "string",
                    date: "2021-05-26T14:41:11.583Z",
                    platform: "string",
                    invitationLink: "string",
                },
                {
                    id: 0,
                    type: "string",
                    subject: "string",
                    date: "2021-05-26T14:41:11.583Z",
                    platform: "string",
                    invitationLink: "string",
                }
            ]

    }

    },
    

    


}
</script>

<style scoped lang="scss">

.vertical {
    border-left: 2px solid rgb(209, 146, 218);
    height: 40rem;
    position:absolute;
    left: 50%;
    margin-top: 3%;
    margin-bottom: 3%;
}

p, a{
    font-size: x-large ;
}

h1{
    font-weight: 100;
    text-align:center;
}

a{
    background-color:white;
    color:black;
    width: 90%;
    height: 10%;
    border-radius: 0.7rem;
    padding: 0.5%;
}

.wrapper{
    display: grid;
    grid-template-rows: 1fr;
    grid-template-columns: 1fr 1fr;
    grid-template-areas: "firstColumn secondColumn";
  
}

.first_column{
    grid-area: firstColumn;
    padding: 10%;
}

.second_column{
    grid-area: secondColumn;
    padding: 10%;
}

.event{
    background: rgb(221, 205, 223);
    margin-top: 5%;
    padding: 2%;
    border-radius: 1rem;
}


</style>