// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {

    // Login message

    if ($("#login-btn") !== null) {
        $("#login-btn").on("click", function () {
            $(".error-msg").remove();
            $("#login-form").validate();
            if ($("#login-form").valid() === true) {
                $("#login-spinner").removeClass("d-none");
            }
        })
    }

    // Registration message

    if ($("#registration-btn") !== null) {
        $("#registration-btn").on("click", function () {
            $(".error-msg").remove();
            $("#registration-form").validate();
            if ($("#registration-form").valid() === true) {
                $("#registration-spinner").removeClass("d-none");
            }
        })
    }

    // User's profile modal

    const fulfillUsersProfile = data => {

        if (data.avatar === "not set") {
            $("#user-image").attr("src", `/uploads/no-image.jpg`);
        } else {
            $("#user-image").attr("src", `${data.avatar}`);
        }

        $("#user-profile-posts").attr("href", `/Post/FindUsersPosts?userId=${data.userId}`);
        $("#user-name").text(`${data.userName}'s`)
        $("#user-first-name").text(`${data.firstName}`);
        $("#user-last-name").text(`${data.lastName}`);
        $("#nickname").text(`${data.userName}`);
        $("#user-email").text(`${data.email}`);
        $("#user-joined").text(`${data.joined.substr(8, 2)}/${data.joined.substr(5, 2)}/${data.joined.substr(0, 4)}`);
        $("#users-posts-count").text(`${data.postsCount}`);
        $("#users-replies-count").text(`${data.repliesCount}`);
        $("#users-messages-count").text(`${data.messagesCount}`);
        $("#UserProfileModal").modal("show");

    }

    const getUsersInfo = (userId, refresh = false) => {

        if ($("#user-name").text() !== "" && refresh === false) {
            return $("#UserProfileModal").modal("show");
        }

        $.ajax({
            url: `/User/FindUser?userId=${userId}`,
            type: 'GET',
            contentType: "application/json",
            success: function (data) {
                $("#UserProfileLabel").removeClass("mx-auto");
                $("#accordionExample").show();
                fulfillUsersProfile(data);
            },
            error: function (error) {
                $("#UserProfileLabel").addClass("mx-auto").text(`${error.responseJSON.message}`);
                $("#accordionExample").hide();
                $("#profile-modal").css("min-height", "177px")
                $("#UserProfileModal").modal("show");
            }
        })

    }

    if ($("#user-profile") !== null) {
        $("#user-profile").on("click", function () {
            getUsersInfo($(this).attr("data-userId"));
        })
    }

    const cleanUpdateForm = () => {

        $("#info-first-name").val("");
        $("#info-last-name").val("");
        $("#info-email").val("");

    }

    const cleanChangePassForm = () => {

        $("#old-password").val("");
        $("#new-password").val("");
        $("#confirm-new-password").val("");

    }

    if ($("#change-profile-btn") !== null) {

        $("#change-profile-btn").on("click", function (e) {
            e.preventDefault();
            var file = $("input[type=file]");
            var form = $("#info-form")[0];
            var formData = new FormData(form);
            formData.append("UserImage", file[0].files[0]);
            formData.append("FirstName", $("#info-first-name").val());
            formData.append("LastName", $("#info-last-name").val());
            formData.append("Email", $("#info-email").val());
            $.ajax({
                url: "/User/UpdateUserInfo",
                type: 'POST',
                data: formData,
                contentType: false,
                processData: false,
                success: function (data) {
                    console.log("RESPONSE DATA: ", data);
                    $("#profile-spinner").hide();
                    $("#change-info-msg").text(data.message);
                    getUsersInfo(data.user.userId, true);
                    cleanUpdateForm();
                },
                error: function (error) {
                    $("#profile-spinner").hide();
                    $("#change-info-msg").text(error.message);
                }
            })
        })

    }

    if ($("#change-password-btn") !== null) {

        $("#change-password-btn").on("click", function (e) {
            e.preventDefault()
            $("#password-spinner").show();
            const data = {
                OldPassword: $("#old-password").val(),
                NewPassword: $("#new-password").val(),
                ConfrimNewPassword: $("#confirm-new-password").val()
            }
            $.ajax({
                url: "User/ChangePassword",
                type: 'POST',
                data: JSON.stringify(data),
                contentType: "application/json",
                success: function (data) {
                    $("#password-spinner").hide();
                    $("#change-pass-msg").text(data.message);
                    cleanChangePassForm();
                },
                error: function (error) {
                    $("#password-spinner").hide();
                    $("#change-pass-msg").text(error.message);
                }
            })
        })

    }

});