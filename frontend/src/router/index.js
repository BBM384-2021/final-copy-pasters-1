import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/Home.vue'
import SignIn from "../components/Home/SignIn.vue";
import SignUp from "../components/Home/SignUp.vue";
import QueSelectClub from '../views/QueSelectClub.vue'
import Questionnaire from '../views/Questionnaire.vue'
import QuestionnaireResult from '../views/QuestionnaireResult.vue'
import JoinMoreSubClubs from '../views/JoinMoreSubClubs.vue'
import EntryPage from '../views/EntryPage.vue'
import SubClubPage from "../views/SubClubPage.vue"
import SupportPage from '../views/SupportPage.vue'
import SupportInfo from '../components/Support/SupportInfo.vue'
import PrivateMessage from '../views/PrivateMessage.vue'
import ProfileAndSetting from '../views/ProfileAndSetting.vue'
import ProfilePage from '../views/ProfilePage.vue'
const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/sign_in',
    name: 'SignIn',
    component: SignIn
  },
  {
    path: '/sign_up',
    name: 'SignUp',
    component: SignUp
  },
  {
    path: '/sub_club_selection',
    name: 'QueSelectClub',
    component: QueSelectClub
  },
  {
    path: '/questionnaire',
    name: 'Questionnaire',
    component: Questionnaire
  },
  {
    path: '/questionnaire_result',
    name: 'QuestionnaireResult',
    component: QuestionnaireResult
  },
  {
    path: '/join_more_sub_clubs',
    name: 'JoinMoreSubClubs',
    component: JoinMoreSubClubs
  },
  {
    path: '/entry_page',
    name: 'EntryPage',
    component: EntryPage
  },
  {
    path: '/sub_club_page/:subclubname',
    name: 'SubClubPage',
    component: SubClubPage
  },
  {
    path: '/support_page',
    name: 'SupportPage',
    component: SupportPage
  },
  {
    path: '/support_info',
    name: 'SupportInfo',
    component: SupportInfo
  },
  {
    path: '/private_message',
    name: 'PrivateMessage',
    component: PrivateMessage
  },
  {
    path: '/profile_page',
    name: 'ProfileAndSetting',
    component: ProfileAndSetting
  },
  {
    path: '/profile_page/:firstName',
    name: 'ProfilePage',
    component: ProfilePage
  },
  
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
