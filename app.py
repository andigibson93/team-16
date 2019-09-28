from flask import Flask, render_template, request, redirect, url_for
app = Flask(__name__)

# Route for index
@app.route("/")
def index():
    return render_template('index.html')

# Route for survey & handle POST
@app.route('/survey', methods=['GET', 'POST'])
def survey():
    if request.method == 'POST':
        # form submitted
        

        # redirect after POST handling, redirect can be to the same route or somewhere else
        return redirect(url_for('index'))

    # show the form (wasn't submitted)
    return render_template('survey.html')

<<<<<<< HEAD
@app.route('/signin', methods=['GET', 'POST']
def signin():
    return render_template('signin.html')

@app.route('/volunteer', methods=['GET', 'POST'])
=======
@app.route('/volunteer')
>>>>>>> 846b6901f922055655bb413cf6e70353c4bf21f2
def volunteer():
    return render_template('volunteer.html')

@app.route('/play')
def play():
    return render_template('play.html')

if __name__ == "__main__":
    app.run(debug=True)