$(".campaign-link").click(function (event) {
    event.preventDefault();
    let id = $(this).attr("data-id");
    let title = $(this).attr("data-title");
    $(".modal-title").html(title);
    $("#campaignModal").modal('toggle');
    $(".modal-campaign").html("Loading");
    $(".modal-campaign").load("/Fundraising/Campaign", { campaign: id, partial: true});
});