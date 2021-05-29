// Delay a certain event, in this case, 2000ms
// This example can be used as a splash screen
Handler().postDelayed({
    startActivity(Intent(this, LoginActivity::class.java))
    // close this activity
    finish()
}, 2000 )