from flask import Flask, render_template, request, redirect, url_for
app = Flask(__name__)
badges=[]

# Route for index
@app.route("/")
def index():
    return render_template('index.html')

# Route for survey & handle POST
@app.route('/survey', methods=['GET', 'POST'])
def survey():
    if request.method == 'POST':
    	badges.add("Survey badge")
    	print(badges.get(0))
    	return redirect(url_for('surveyResults.html'))

    # show the form (wasn't submitted)
    return render_template('survey.html')

@app.route('/volunteer')
def volunteer():
	return render_template('volunteer.html')



@app.route('/viewBadges', methods=['GET'])
def viewBadges():
	return render_template('viewBadges.html')




@app.route('/play')
def play():
    return render_template('play.html')

if __name__ == "__main__":
    app.run(debug=True)