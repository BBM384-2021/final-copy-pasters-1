<template>
<div class="wrapper">
    <div class="first-row">
        <p>How would you rate the sub-club experience?</p>
        <div class="rate">
            <input type="radio" id="star5" name="rate" value="5" />
            <label for="star5" title="text">5 stars</label>
            <input type="radio" id="star4" name="rate" value="4" />
            <label for="star4" title="text">4 stars</label>
            <input type="radio" id="star3" name="rate" value="3" />
            <label for="star3" title="text">3 stars</label>
            <input type="radio" id="star2" name="rate" value="2" />
            <label for="star2" title="text">2 stars</label>
            <input type="radio" id="star1" name="rate" value="1" />
            <label for="star1" title="text">1 star</label>
        </div><br><br>
        <p>Your rating help us to improve our servis quality.</p>
    </div>
    <form class="second-row" action="#">
        <input type="text" v-model="comment" class="review" placeholder="Write your review (it will be anonymous)"/>
        <span  id='clickableAwesomeFont'><i class="fa fa-paper-plane" aria-hidden="true"></i></span>
    </form>
    <div class="third-row">
        <div class="rate-and-reviews-wrapper">
            <div class="rates-and-reviews" v-for="rateAndReview in ratesAndReviews" :key="rateAndReview">
                <div v-if="rateAndReview.rate == '5'">
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star"></span>
                </div>
                <div v-if="rateAndReview.rate == '4'">
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star "></span>
                </div>
                <div v-if="rateAndReview.rate == '3'">
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star"></span>
                    <span class="fa fa-star"></span>
                </div>
                <div v-if="rateAndReview.rate == '2'">
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star"></span>
                    <span class="fa fa-star"></span>
                    <span class="fa fa-star"></span>
                </div>
                <div v-if="rateAndReview.rate == '1'">
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star"></span>
                    <span class="fa fa-star"></span>
                    <span class="fa fa-star"></span>
                    <span class="fa fa-star"></span>
                </div>
                 <p id="review">{{rateAndReview.review}}</p>
            </div>
        </div>
    </div>
</div>
</template>

<script>
export default {
    data() { 
        return{
            ratesAndReviews:[
                {
                review: "it has nice a content",
                rate: 5,
                subClubId: 0
                },
                {
                review: "could be better but it is nice",
                rate: 4,
                subClubId: 0
                },
                {
                review: "need more meetings",
                rate: 2,
                subClubId: 0
                },
                
            ],
           
        }

    },

    methods:{
        getRateNumber(num){
            return num.toString();
        },

    }
    

    


}
</script>

<style scoped lang="scss">

.wrapper{
    display: grid;
    grid-template-rows:3fr 1fr 2fr ;
    grid-template-areas: "firstRow"
                        "secondRow"
                        "thirdRow";

}

.first-row{
    grid-area: firstRow;
    justify-self: center;
    padding: 3%;
}

.second-row{
     grid-area: secondRow;
     background: rgb(221, 205, 223);
     justify-self: center;
     height: 50%;
     width: 70%;
     border-radius: 1rem;
     margin-top: -10%;
}
.review{
    margin-top: 2.5%;
    margin-left: 5%;
    width: 90%;
    line-height: 2em;
    border-top-style: hidden;
    border-right-style: hidden;
    border-left-style: hidden;
    border-bottom-style: hidden;
    border-radius: 1rem;
}

.third-row{
    grid-area: thirdRow;
    background: rgb(221, 205, 223);
    justify-self: center;
    width: 70%;
    border-radius: 1rem;
    margin-top: -10%;
    
}

.rates-and-reviews{
    padding: 3%;
}

.rate {
   float:left;
   margin-left: 25%;
   
}

p#review{
    background: white;
    padding: 2%;
    border-radius: 1rem;
}

#clickableAwesomeFont {
     cursor: pointer
}


.rate:not(:checked) > input {
    position:absolute;
    top:-9999px;
    
}
.rate:not(:checked) > label {
    float:right;
    width:1em;
    overflow:hidden;
    white-space:nowrap;
    cursor:pointer;
    font-size:30px;
    color:#ccc;
}
.rate:not(:checked) > label:before {
    content: '★ ';
}
.rate > input:checked ~ label {
    color: #ffc700;    
}
.rate:not(:checked) > label:hover,
.rate:not(:checked) > label:hover ~ label {
    color: #deb217;  
}
.rate > input:checked + label:hover,
.rate > input:checked + label:hover ~ label,
.rate > input:checked ~ label:hover,
.rate > input:checked ~ label:hover ~ label,
.rate > label:hover ~ input:checked ~ label {
    color: #c59b08;
}

.checked {
  color: orange;
}
</style>