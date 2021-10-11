<script>
import QuestionChoices from '@/src/components/question-choices.vue'
export default {
  components: { QuestionChoices },
  data() {
    return {
      loading: false,
      questions: null,
      error: null,
    }
  },
  watch: {
    // call again the method if the route changes
    $route: 'fetchData',
  },
  created() {
    this.fetchData()
  },
  methods: {
    fetchData() {
      this.error = this.post = null
      this.loading = true
      // get question id
      // const questionId = this.$route.params.id
      // get questions
      setTimeout(() => {
        this.questions = [
          {
            questionId: 1,
            text: 'What kind of food do you like?',
            choices: [
              {
                choiceId: 1,
                text: 'Hamburger',
              },
              {
                choiceId: 2,
                text: 'Chicken',
              },
              {
                choiceId: 3,
                text: 'Noodle',
              },
              {
                choiceId: 4,
                text: 'Other',
              },
            ],
          },
        ]
        this.loading = false
      }, 2000)
    },
  },
}
</script>

<template>
  <div class="questions">
    <div v-if="loading" class="loading">
      Loading...
    </div>

    <div v-if="error" class="error">
      {{ error }}
    </div>

    <div v-for="(question, idx) in questions" :key="idx">
      <QuestionChoices :question="question" />
    </div>
  </div>
</template>
