<script>
export default {
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
            choiceId: 1,
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

    <div v-for="(question, qidx) in questions" :key="qidx" class="question">
      <div class="text">
        {{ question.text }}
      </div>
      <div
        v-for="(choice, cidx) in question.choices"
        :key="cidx"
        class="choices"
      >
        <div class="choice">
          <input
            v-model="question.choiceId"
            :value="choice.choiceId"
            type="radio"
          />
          <label>{{ choice.text }}</label
          ><br />
        </div>
      </div>
    </div>
  </div>
</template>

<style lang="scss">
@import '@design';
div.text {
  padding: 20px 0;
}
.questions {
  .question {
  }
}
.choices {
  .choice {
    padding: 20px;
    border: 1px solid #ccc;
    border-radius: 10px;
    margin-bottom: 20px;
    label {
      margin-left: 10px;
    }
  }
}
</style>
