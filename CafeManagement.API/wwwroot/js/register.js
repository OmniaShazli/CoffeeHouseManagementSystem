document.addEventListener('DOMContentLoaded', () => {
  if (isLoggedIn()) {
    window.location.href = isAdmin() ? 'admin.html' : 'index.html';
    return;
  }

  $('#register-form').addEventListener('submit', handleRegister);
});

async function handleRegister(event) {
  event.preventDefault();

  const button = $('#register-submit');

  const payload = {
    firstName:       $('#reg-first-name').value.trim(),
    lastName:        $('#reg-last-name').value.trim(),
    email:           $('#reg-email').value.trim(),
    phoneNumber:     $('#reg-phone').value.trim(),
    password:        $('#reg-password').value,
    confirmPassword: $('#reg-confirm').value,
  };

  if (
    !payload.firstName ||
    !payload.lastName ||
    !payload.email ||
    !payload.password ||
    !payload.confirmPassword
  ) {
    showToast(
      'Please fill in your first name, last name, email and password.',
      'info'
    );
    return;
  }

  if (payload.password !== payload.confirmPassword) {
    showToast('Passwords do not match. Please re-enter them.', 'error');
    return;
  }

  setLoading(button, true, 'Creating your account…');

  try {
    await AuthAPI.register(payload);

    try {
      const authResponse = await AuthAPI.login({
        email: payload.email,
        password: payload.password,
      });

      if (authResponse && authResponse.token && authResponse.user) {
        saveSession(authResponse);

        showToast('Your account is ready — welcome to the house!');

        setTimeout(() => {
          window.location.href = 'index.html';
        }, 800);

        return;
      }
    } catch {
      // Registration succeeded, but automatic login failed.
      // User will be redirected to the login page.
    }

    showToast('Account created! Please sign in.', 'info');

    setTimeout(() => {
      window.location.href = 'login.html';
    }, 900);

  } catch (error) {
    console.error('REGISTER ERROR:', error);

    showToast(
      error.message || 'Something went wrong while creating your account.',
      'error'
    );

    setLoading(button, false, 'Create account');
  }
}

function setLoading(button, isLoading, label) {
  button.disabled = isLoading;

  button.innerHTML = isLoading
    ? `< span class="btn-spinner" ></span > ${ label }`
    : `${ label } <i data-lucide="arrow-right"></i>`;

  refreshIcons();
}
