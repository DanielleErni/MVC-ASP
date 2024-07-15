// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
<script>
    $('#actionModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget); // Button that triggered the modal
        var itemId = button.data('id'); // Extract info from data-* attributes

        // Update the modal's content.
        var modal = $(this);
        modal.find('#updateLink').attr('href', '/Order/Update/' + itemId);
        modal.find('#deleteLink').attr('href', '/Order/Delete/' + itemId);
    });
</script>